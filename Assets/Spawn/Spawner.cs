using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject spider;
    public GameObject potion;
    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	
    public  void Spawn_Spider()
    {
        GameObject obj = Instantiate(spider);
        obj.transform.parent = transform;
        obj.transform.position = new Vector3(Random.value * 100 - 50, transform.position.y, Random.value * 100 - 50);
    }
    /// <summary>
    /// 0 - health
    /// </summary>
    public void Spawn_Potion(int type,int fullness)
    {
        GameObject obj = Instantiate(potion);
        switch (type)
        {
            case 0:
                obj.GetComponent<Potion_Controller>().power = fullness / 10;
                break;
        }
        obj.transform.parent = transform;
        obj.transform.position = new Vector3(Random.value * 100 - 50, transform.position.y+potion.transform.localScale.y, Random.value * 100 - 50);

    }
}
