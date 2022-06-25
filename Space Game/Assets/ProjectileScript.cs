using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float waitDestroyTime;
    float speed = 500f;
    Rigidbody2D rb2d;
    public GameObject target;
    Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveDir = (target.transform.position - transform.position).normalized * speed;
        rb2d.velocity = new Vector2(moveDir.x, moveDir.y);
        StartCoroutine(DestroyBulletTimer());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //explosion effects
        DestroyProjectile(); 
    }

    void DestroyProjectile()
    {
        //ex efx
        Destroy(gameObject);
    }

    IEnumerator DestroyBulletTimer()
    {
        yield return new WaitForSeconds(waitDestroyTime);
        DestroyProjectile();
        yield return null;
    }
}
