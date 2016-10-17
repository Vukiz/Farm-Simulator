using UnityEngine;
using System.Collections;

public class SpawnerBehavior : MonoBehaviour {
    public GameObject spawnedObj;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj =  Instantiate(spawnedObj);
            obj.transform.parent = transform;
            obj.transform.position = new Vector3(Random.value * 100 - 50, transform.position.y, Random.value * 100 - 50);
        }
    }
}
