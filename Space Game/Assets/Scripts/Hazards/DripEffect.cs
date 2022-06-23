using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripEffect : MonoBehaviour
{
    [SerializeField]private Transform machine;
    private MonoBehaviour dark;
    // Start is called before the first frame update
    void Start()
    {
        machine =  this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.transform != machine && dark != null)
        {
            if(collision.tag == "Enemy")
            {
                dark.StartCoroutine("darken");
            }
            Destroy(gameObject);

        }
    }
}
