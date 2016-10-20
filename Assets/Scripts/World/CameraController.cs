using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    Vector3 movsespeed = new Vector3();
    public int cameraCurrentZoom = 8;
    public float zoomSpeed = 3;
    float cameraMAXzoom = 100;
    float cameraMINzoom = 10;
    // Use this for initialization
    void Start () {
        Camera.main.orthographicSize = cameraCurrentZoom;
	}
	
	void Awake()
    {
        Application.targetFrameRate = 200;
    }
	void Update () {
        
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            movsespeed.z = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movsespeed.z = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movsespeed.x = 1 ;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movsespeed.x = -1;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            movsespeed.z = 0;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            movsespeed.z = 0;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            movsespeed.x = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            movsespeed.x = 0;
        }
        transform.position += movsespeed;
        if(Input.GetAxis("Mouse ScrollWheel")> 0)
        {
            if (Camera.main.fieldOfView < cameraMAXzoom) Camera.main.fieldOfView += zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView > cameraMINzoom) Camera.main.fieldOfView -= zoomSpeed;
        }
      
    }
}
