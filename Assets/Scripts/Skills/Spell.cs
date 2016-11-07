using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class  Spell: MonoBehaviour
{
    public bool available
    {
        get
        {
            return isAvailable;
        }
        set
        {
            isAvailable = value;
            CD = 0;

        }
    }
    public bool isAvailable;
    float CD;
    public float CDduration;
    public float cooldownTime;
    public KeyCode skillKey;
    public float cooldown
    {
        set
        {
            if (value <= 0)
            {
                CD = 0;
            }
            else CD = value;
        }
        get
        {
            return CD;
        }
    }
    public int range;
    public abstract void cast();
    public void Update()
    {
        if (Input.GetKeyDown(skillKey))
        {
            cast();
        }
    }
    public void OnMouseDown()
    {
        cast();
    }
    
}
