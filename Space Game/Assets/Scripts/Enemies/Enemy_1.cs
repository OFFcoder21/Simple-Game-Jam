using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    public float enemyWalkSpeed;
    [HideInInspector]
    public bool patrol;
    private bool flip;

    public Rigidbody2D rb2d;
    public Transform groundCheckPos;
    public Collider2D bodyColl;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    void Start()
    {
        patrol = true; 
    }

    private void FixedUpdate()
    {
        if (patrol)
        {
            flip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Update()
    {
        if (patrol)
        {
            Patrol();
        }
    }

    public void Patrol()
    {
        if (flip || bodyColl.IsTouchingLayers(wallLayer))
        {
            Flip();
        }
        rb2d.velocity = new Vector2(enemyWalkSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
    }

    void Flip()
    {
        patrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        enemyWalkSpeed *= -1;
        patrol = true;
    }
    
}
