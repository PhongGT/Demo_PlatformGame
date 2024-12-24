using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private bool isPlayer;    
    [SerializeField] protected string curAnimation;
    
    private float hp;
    private float maxHp =100f;

    

    [SerializeField] protected Animator animator;
    void Start()
    {
        
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnInit()
    {
        hp = maxHp;
    }
    public virtual void OnDespawn()
    {

    }
    public void OnHit(int amount)
    {
        hp = Mathf.Clamp(hp-amount, 0, maxHp);
        if(hp <= 0)
        {
            OnDeath();
        }
    }

    public virtual void OnDeath()
    {
        if (isPlayer)
        {

        }

        else {
        
        }
    }

    protected void ChangeAnimation(string state)
    {

        if (curAnimation != state)
        {
            animator.ResetTrigger(curAnimation);
            curAnimation = state;
            animator.SetTrigger(state);
        }
    }
}
