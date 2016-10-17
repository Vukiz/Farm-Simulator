using UnityEngine;
using System.Collections;

public class MapAwayCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Destroy(other.gameObject);
    }
}
