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

    LinkedList<Image> Hearts;

    void Start()
    {
        Hearts = new LinkedList<Image>();
        fillHearts();
    }
    void fillHearts()
    {
        currentHealth = WhosHealth.HitPoints;

        int heartHalvesCount = currentHealth / (healthPerHeart / 2);// how much heart halves we have?
        Debug.Log("Updating Hearts");
        addHeartsUntill(heartHalvesCount);

    }
    void addHeartsUntill(int halvesCount)
    {
        for (int i = 0; i < halvesCount / 2; i++)
        {
            addFullHeart(i);
        }
        if (halvesCount % 2 != 0)
        {
            addHalfHeart();
        }
    }
    public void UpdateHearts()
    {

        currentHealth = WhosHealth.HitPoints;
        int heartHalvesCount = currentHealth / (healthPerHeart / 2) + 1;
        if (heartHalvesCount == Hearts.Count)
        {
            Debug.Log("Hearts are Fine");
            return;
        }
        if (heartHalvesCount > Hearts.Count * 2)
        {
            Debug.Log("Hearts needs to be added");
            addHeartsUntill(heartHalvesCount);
        }
        else
        {
            Debug.Log("Hearts needs to be deleted");
            removeHeartsUntill(heartHalvesCount);
        }


    }
    void addHalfHeart()
    {
        Debug.Log("Adding half");
        Image newHeart = Instantiate(Heart);
        newHeart.transform.SetParent(transform);
        newHeart.transform.position = transform.position;
        newHeart.sprite = heartsImages[1];
        newHeart.transform.position += new Vector3(55 * Hearts.Count, 0, 0);
        Hearts.AddLast(newHeart);
    }
    void addFullHeart(int at)// at -> this HEART position in healthbar
    {
        Image newHeart = Instantiate(Heart);
        newHeart.transform.SetParent(transform);
        newHeart.transform.position = transform.position;
        newHeart.transform.position += new Vector3(55 * at, 0, 0);
        Hearts.AddLast(newHeart);
    }
    void removeHeartsUntill(int halvesCount)
    {
        int heartHalvesDifference = (Hearts.Count * 2 - halvesCount);
        Debug.Log("Removing " + heartHalvesDifference + " Heart half");
        for (int i = 0; i < heartHalvesDifference / 2; i++)
        {
            Destroy(Hearts.Last.Value.gameObject);
            Hearts.RemoveLast();
        }
        if (heartHalvesDifference % 2 != 0)
        { 
            Destroy(Hearts.Last.Value.gameObject);
            Hearts.RemoveLast();
            addHalfHeart();
        }
    }

}
