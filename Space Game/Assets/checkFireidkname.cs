using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFireidkname : MonoBehaviour
{
    public float enableColl = 0.5f;
    public Collider2D coll;
    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        bool hit = Physics2D.Raycast(transform.position, Vector2.down, enableColl);
        if (hit)
        {
            coll.gameObject.SetActive(true);
        }
        else if (!hit)
        {
            coll.gameObject.SetActive(false);
        }
    }
}
