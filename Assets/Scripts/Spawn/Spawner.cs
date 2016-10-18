using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject spider;
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
}
