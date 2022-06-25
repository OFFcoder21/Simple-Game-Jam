using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float wait;
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    public float enemyHealth;
    
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if(groundInfo == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        if(collision.collider.tag == "Player")
        {
            transform.position = new Vector2(Vector2.zero.x, Vector2.zero.y);
            StartCoroutine(waitBeforeMoving());

        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Bullet")
        {
            DamageEnemy(1f);
        }
        if(coll.tag == "FireHurt")
        {
            DamageEnemy(1.5f); ;
        }
    }

    void DamageEnemy(float damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            //play death anim
            //(spawn coin)
            Destroy(gameObject);
        }
    }

    IEnumerator waitBeforeMoving()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        yield return null;
    }
}
