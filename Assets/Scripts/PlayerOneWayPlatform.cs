using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerOneWayPlatform : MonoBehaviour
{
    public GameObject currentPlatform;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private Rigidbody2D playerRb;

    private void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentPlatform != null)
            {
                
                StartCoroutine(DisableCollision());
                playerRb.velocity = new Vector2(playerRb.velocity.x, 20f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        CompositeCollider2D platformCollider = currentPlatform.GetComponent<CompositeCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        //int curLayer =  currentPlatform.layer;
        //currentPlatform.layer = 0;
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        //currentPlatform.layer = curLayer;
    }
}
