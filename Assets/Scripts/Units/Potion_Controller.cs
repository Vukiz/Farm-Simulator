using UnityEngine;
using System.Collections;

public class Potion_Controller : MonoBehaviour {
    public int power
    {
        get; set;
    }
    public int potion_type { get; set; }
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero")
        {
            //Debug.Log("power: " + power);
            Unit oth =  other.gameObject.GetComponent<Unit>();
            if (oth.HP < oth.maxHP)
            {
                oth.Heal(power);
                //Debug.Log(other.gameObject.GetComponent<Unit>().HP);
                Destroy(gameObject);
            }
        }
    }
}
