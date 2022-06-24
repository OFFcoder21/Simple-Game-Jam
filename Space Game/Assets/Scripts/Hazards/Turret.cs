using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private Transform target;
    [SerializeField] private float range;
    [SerializeField]private bool detect;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireRate;
    private float nextTimeToShoot = 0f;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)gun.transform.position;
        RaycastHit2D aimplayer = Physics2D.Raycast(gun.transform.position, direction, range);
        Debug.DrawRay(gun.transform.position, direction, Color.green);
        if (aimplayer)
        {
            if (aimplayer.collider.gameObject.tag == "Player")
            {
                if (!detect)
                {
                    detect = true;
                }
            }
            else
            {
                if (detect)
                {
                    detect = false;
                }
            }

        }
        else if (detect) 
        {
            detect = false;
        }

        if(detect)
        {

            gun.transform.up = direction;
            if(Time.time>nextTimeToShoot)
            {
                nextTimeToShoot = Time.time + 1 / fireRate;
                shoot();
                
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gun.transform.position, range);
    }
    private void shoot()
    {
        GameObject bulletIns = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        bulletIns.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed);
    }
}
