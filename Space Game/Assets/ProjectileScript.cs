using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.right * speed * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("AhhHHHhhhh");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //explosion effects
        Destroy(gameObject);  
    }
}
