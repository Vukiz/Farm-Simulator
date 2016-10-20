using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthController : MonoBehaviour
{

    int maxHealth;
    public int healthPerHeart;
    public GameObject Heart;
    public GameObject WhosHealth;
    public Sprite[] heartsImages;
    int currentHealth;

    ArrayList Hearts;

    void Start()
    {
        maxHealth = WhosHealth.GetComponent<HeroController>().HitPoints;
        Hearts = new ArrayList();
        UpdateHearts();
    }
    public void UpdateHearts()
    {
        currentHealth = WhosHealth.GetComponent<HeroController>().HitPoints;

        int heartHalvesCount = ((currentHealth * 2) / healthPerHeart);// how much heart halves we have?
        Debug.Log(heartHalvesCount);

        for (int i = 0; i < heartHalvesCount / 2; i++)
        {
            GameObject newHeart = Instantiate(Heart);
            newHeart.transform.SetParent(transform);
            newHeart.transform.position = transform.position;
            Hearts.Add(newHeart);
            newHeart.transform.position += new Vector3(55 * i, 0, 0);
        }
        if (heartHalvesCount % 2 != 0)
        {
            GameObject newHeart = Instantiate(Heart);
            newHeart.transform.SetParent(transform);
            newHeart.transform.position = transform.position;
            newHeart.GetComponent<Image>().sprite = heartsImages[1];
            newHeart.transform.position += new Vector3(55 * Hearts.Count, 0, 0);
            Hearts.Add(newHeart);
        }

    }
}
