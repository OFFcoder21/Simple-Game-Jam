using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float waitDestroyTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBulletTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //explosion effects
        DestroyProjectile(); 
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    IEnumerator DestroyBulletTimer()
    {
        yield return new WaitForSeconds(waitDestroyTime);
        DestroyProjectile();
        yield return null;
    }
}
