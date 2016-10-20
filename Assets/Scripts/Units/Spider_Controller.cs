using UnityEngine;
using System.Collections;

public class Spider_Controller : Unit {
    // Use this for initialization
    float startTime;
    Vector3 endPosition;
    Vector3 currentDir;
    Vector3 startPosition;
    float Distance;
    float DistanceDone;
	void Start () {
        currentState = state.idle;
        attackAnimationtime = 1.10f;

    }
	
	// Update is called once per frame
	void Update () {
        if (currentState != state.dead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //ProcessLeftClick(); -> moves spiders with left-Click
            }
        }
        switch (CurrentState)
        {
            case state.moving_to_Place:
            case state.moving_to_Start_Action:
                moveTo(endPosition);
                break;

        }
        
    }
    void ProcessLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit h in hits)
        {
            if (h.transform.gameObject.layer == 9)
            {
                startTime = Time.time;
                startPosition = transform.position;
                endPosition = new Vector3(h.point.x, transform.position.y, h.point.z);
                CurrentState = state.moving_to_Place;

                Distance = Vector3.Distance(startPosition, endPosition);
                DistanceDone = 0;
                if (Distance <= 0.1f)
                {
                    CurrentState = state.idle;
                }
                else
                {
                    CurrentState = state.moving_to_Place;
                }
                break;
            }
        }

    }
    void moveTo(Vector3 end)
    {
        float distCovered = (Time.time - startTime) * UnitSpeed;
        DistanceDone = distCovered / Distance; // [0;1]
        Vector3 newPosition = Vector3.Lerp(startPosition, end, DistanceDone);
        if (!(newPosition - transform.position == Vector3.zero))
        {
            transform.rotation = Quaternion.LookRotation(newPosition - transform.position);
            transform.position = Vector3.Lerp(startPosition, end, DistanceDone);
        }
        if (DistanceDone >= 0.99f)
        {
            CurrentState = state.idle;
        }
    }
   

}
