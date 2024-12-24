using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private bool isPlayer;    
    [SerializeField] protected string curAnimation;
    
    private float hp;

    public bool isDead;

    [SerializeField] protected Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnInit()
    {

    }
    public virtual void OnDespawn()
    {

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
