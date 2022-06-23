using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHitting : MonoBehaviour
{
    [SerializeField] float laserReloadTime;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private BoxCollider2D box;
    //Hitting the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Consequences for touching the laser
        }
    }
    IEnumerator start()
    {
        
        while (true)
        {
            yield return new WaitForSecondsRealtime(laserReloadTime);
            sprite.enabled = false;
            box.enabled = false;
            yield return new WaitForSecondsRealtime(laserReloadTime);
            sprite.enabled = true;
            box.enabled = true;
            
        }
    }
    private void Start()
    {
        StartCoroutine("start");
        
    }
}
