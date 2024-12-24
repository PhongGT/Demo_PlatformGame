using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpd;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private IState currentState;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();   
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null) {
            currentState.OnExecute(this);
        }
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new IdleState());
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
    }
    public override void OnDeath()
    {
        base.OnDeath();
    }
    public void ChangeState(IState state)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = state;
        if(currentState != null) {
            
                currentState.onEnter(this);
            }
    }
    public void MovingTo()
    {
        ChangeAnimation("Run");
        rb.velocity = this.transform.right * moveSpd;
    }
    public void Stop()
    {
        rb.velocity = Vector2.zero;
        ChangeAnimation("Idle");
    }
    public void Attack()
    {

    }
    public bool CheckInRange()
    {
        return true;
    }
}
