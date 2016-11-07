using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthController : MonoBehaviour
{
    public int healthPerHeart;
    public Image Heart;
    public HeroController WhosHealth;
    public Sprite[] heartsImages;
    int currentHealth;
    int currentHeartPosition;
    int lastUpdateHealth;
    LinkedList<Image> Hearts;
    void Start()
    {
        fillHealth();
    }
    public void fillHealth()
    {
        Hearts = new LinkedList<Image>();
        lastUpdateHealth = 0;
        currentHeartPosition = 0;
        UpdateHearts();
    }
    public void UpdateHearts()
    {
        currentHealth = WhosHealth.HitPoints;      
       // Debug.Log(currentHealth + " " + lastUpdateHealth); 
        if (currentHealth > lastUpdateHealth)
        {
            removeHeartsLack();
        }
        else
        {
            removeHeartsExcess();
        }
        lastUpdateHealth = currentHealth;

    }
    ///<summary>
    /// 1 : half heart ||
    /// 0 : full heart
    ///</summary>
    void addHeart(int position, int type)
    {
       // Debug.Log("adding heart to " + position +" with type : "+ type);
        Image newHeart = Instantiate(Heart);
        newHeart.transform.SetParent(transform);
        newHeart.transform.position = transform.position;
        newHeart.transform.position += new Vector3(55 * position, 0, 0);
        newHeart.sprite = heartsImages[type];
        Hearts.AddLast(newHeart);

        currentHeartPosition++;
    }

    ///<summary>
    /// Adding hearts to screen until the leak is fixed
    ///</summary>
    void removeHeartsLack()
    {
        Debug.Log("where`s heart lack");

        if (Hearts.Count > 0 && Hearts.Last.Value.sprite == heartsImages[1])
        {
            if ((currentHeartPosition + 1) * healthPerHeart - healthPerHeart / 2 <= currentHealth)
            {
                Hearts.Last.Value.sprite = heartsImages[0];
            }
        }
        while ((currentHeartPosition + 1) * healthPerHeart <= currentHealth)
        {
            addHeart(currentHeartPosition, 0);
        }
        if (currentHealth % 10 >= healthPerHeart / 2)
        {
            addHeart(currentHeartPosition, 1);
        }
    }
    ///<summary>
    ///Removing hearts from screen until the excess is fixed
    ///</summary>
    void removeHeartsExcess()
    {

        //Debug.Log("where`s heart excess");
        while ((currentHeartPosition) * healthPerHeart > currentHealth)
        {
            Destroy(Hearts.Last.Value.gameObject);
            Hearts.RemoveLast();
            currentHeartPosition--;
        }
        if (currentHealth % 10 >= healthPerHeart / 2)
        {
            addHeart(currentHeartPosition, 1);
        }
    }

}
