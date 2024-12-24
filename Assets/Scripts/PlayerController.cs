using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class PlayerController : Character
{
    [Header("")]
    //[SerializeField] protected Animator animator;
    protected Rigidbody2D rb;
    protected PlayerStat stat;
    [SerializeField] protected LayerMask groundLayer;


    [Header("Check State")]
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool isAttack;
    [SerializeField] private bool isIdle;
    [SerializeField] private float dir;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isDead;

    [Header("Kunai")]
    [SerializeField] protected GameObject kunaiPrefab;
    [SerializeField] protected GameObject throwPoint;
    [SerializeField] protected GameObject[] kunaiPoooling;
    
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInChildren<Rigidbody2D>();
        stat = GetComponentInParent<PlayerStat>();
        
        
    }
    private void FixedUpdate()
    {
        CheckGrounded();   
        ClampGravity();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Input.GetAxisRaw("Horizontal");  
        Jump();
        Move();
        Throw();
        
    }

    private void Throw()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GetKunai();
        }
    }

    private void GetKunai()
    {
        GameObject obj = ObjPool.instance.GetPooledObj();
        if (obj != null)
        {
            obj.transform.position = throwPoint.transform.position;
            obj.transform.rotation = throwPoint.transform.rotation;
            obj.GetComponent<Kunai>().Despawn();
            obj.SetActive(true);
        }
    }

    public void Move()
    {

        if (Mathf.Abs(dir) > 0)
        {
            rb.velocity = new Vector2(dir * stat.Speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(0, dir > 0 ? 0 : 180, 0));
        }
        if (isGrounded && dir != 0 && !isJumping)
        {
            ChangeAnimation("Run");
        }

        if (isGrounded && dir == 0 && !isJumping)
        {
            {
                rb.velocity = Vector2.zero;
                ChangeAnimation("Idle");
            }

        }
    }
    public void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {            
            isJumping = true;
            ChangeAnimation("Jump");
            rb.velocity = new(rb.velocity.x, stat.Jump);

        }
    }

    private void CheckGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, groundLayer);
        isGrounded = ray.collider != null;
        if (isGrounded)
        {
            isJumping = false;
        }
    }
    private void ClampGravity()
    {
        rb.velocity = new Vector2(rb.velocity.x,Mathf.Clamp(rb.velocity.y, -10f, 10f));
    }

}