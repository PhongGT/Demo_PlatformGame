using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public Rigidbody2D rb;
    private float spd = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector2.one * spd;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
    public void Despawn()
    {
        this.gameObject.SetActive(false );
    }
}
