using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHitting : MonoBehaviour
{
    [SerializeField] float laserReloadTime;
    [SerializeField] int damage;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private BoxCollider2D box;

    public void Start()
    {
        StartCoroutine("begin");
        //PlayerController playerController = gameObject.GetComponent<PlayerController>();

    }

    //Hitting the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //playerController.Damage(damage);
            PlayerController playerController = collision.GetComponent<PlayerController>();
            playerController.Damage(damage);

        }
    }
    IEnumerator begin()
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
}
