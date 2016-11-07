using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroController : Unit {
    
    float additionalSpace = 1;
    float startTime;
    float waitingStartTime;
    float lastAttackTime;
    float Distance;
    float DistanceDone;
    
    public HealthController health;
    Vector3 startPosition;
    Vector3 endPosition;
    Transform currentTarget = null;
    int currentScore;
    Text scoreText; 
    override public int HP
    {
        get
        {
            return HitPoints;
        }
        set
        {
            HitPoints = value;
            if (HitPoints < 1)
            {
                die();
            }
            health.UpdateHearts();   
        }
    }
    void Start() {
        currentState = state.idle;
        animator = GetComponent<Animator>();
        animator.SetFloat("AttackCD", attackSpeed);
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }
    void LockTarget(Transform t)//target Drops before locking new
    {
        Debug.Log("Target Locked");

        DropTarget();
        currentTarget = t;
        
    }
    void DropTarget()
    {
       
        if (currentTarget != null)
        {
            if (currentTarget.GetComponent<Unit>().CurrentState == state.dead)
            {
                increaseScore();
            }
            currentTarget = null;
        }

    }
    void increaseScore()
    {
        currentScore++;
        scoreText.text = currentScore.ToString();
    }
    void makeAction()
    {
        if(currentTarget.position - transform.position != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(currentTarget.position - transform.position);
        }
        if (Vector3.Distance(transform.position, currentTarget.position) <= attackRange)//if we are close enough
        {
            if ((Time.time - lastAttackTime) >= attackSpeed)// if we are not on cd
            {
                currentTarget.GetComponent<Unit>().takeDamage(attackDamage);
                lastAttackTime = Time.time;
                if (currentTarget.GetComponent<Unit>().CurrentState == state.dead)
                {
                    DropTarget();
                    CurrentState = state.idle;
                }
            }
            else
            {
                CurrentState = state.wait_for_CD;
                waitingStartTime = Time.time;
            }
        }
        else
        {
            startTime = Time.time;
            startPosition = transform.position;
            CurrentState = state.moving_to_Start_Action;
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
    }
    void makeHeroMove(Vector3 pos )
    {
        DropTarget();
        startTime = Time.time;
        startPosition = transform.position;
        endPosition = pos;
        endPosition.y = transform.position.y;

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
    }
    void lockTargetAndGo(Transform t)
    {
        LockTarget(t);
        startPosition = transform.position;
        if (Vector3.Distance(startPosition, currentTarget.position) > attackRange)
        {
            startTime = Time.time;
            Distance = Vector3.Distance(startPosition, currentTarget.position);
            DistanceDone = 0;
            CurrentState = state.moving_to_Start_Action;
        }
        else
        {
            CurrentState = state.making_Action;
            makeAction();
        }
    }
    void moveToAction()
    {
        moveTo(currentTarget.position);
        if (Vector3.Distance(transform.position, currentTarget.position) <= attackRange - additionalSpace)
        {
            CurrentState = state.making_Action;
        }
    }
    void processLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit h in hits)
        {
            if (h.transform.gameObject.layer == 8)// 8 -> minion
            {
                lockTargetAndGo(h.transform);
                break;
            }
            else
            {
                if (h.transform.gameObject.layer == 9)// 9 -> ground
                {
                    makeHeroMove(h.point);
                }
            }
        }
    }
    void Update() {
        if (currentState != state.dead)
        {
            if (Input.GetMouseButtonDown(1))
            {
                processLeftClick();
            }
            if (Input.GetKeyDown(KeyCode.Q)){ 
                takeDamage(attackDamage);
            }
        }
        switch (currentState)
        {
            case state.making_Action:
                makeAction(); 
                break;
            case state.moving_to_Place:
                moveTo(endPosition);
                if (DistanceDone >= 0.99f)
                {
                    CurrentState = state.idle;
                }
                break;
            case state.moving_to_Start_Action:
                moveToAction();
                break;
            case state.wait_for_CD:
                if(Time.time - waitingStartTime > attackSpeed)
                {
                    CurrentState = state.making_Action;
                }
                break;
           
        }
    }
    
}

