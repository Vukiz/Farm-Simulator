using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {
    protected Animator animator;
    public int HitPoints;
    public float UnitSpeed;
    public float attackSpeed;
    public int attackDamage;
    public int attackRange;
    protected float attackAnimationtime;
    protected state currentState;
    public enum state
    {
        idle,
        making_Action,
        moving_to_Place,
        moving_to_Start_Action,
        wait_for_CD,
        dead
    };
    public void die()
    {
        currentState = state.dead;
        Debug.Log( transform.name + " died");
        gameObject.layer = 2;
    }
    public state CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            //Debug.Log("Changed state to " + value);
            currentState = value;
        }
    }
    public int HP
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
        }
    }
    void OnMouseDown()
    {

        Debug.Log("clicked>\n HP  = " + HP+"\nName = "+ gameObject.name);
    }
}
