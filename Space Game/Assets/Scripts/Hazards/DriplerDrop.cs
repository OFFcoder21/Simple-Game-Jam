using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriplerDrop : MonoBehaviour
{
    [SerializeField] private GameObject drip;
    [SerializeField] private float seconds = 5f;
    Vector2 randomize;
    [SerializeField] private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Dripping");
        //Start Coroutine
        
    }

    IEnumerator Dripping()
    {
        while (true)
        {
            randomize = new Vector2(Random.Range(-1.39f, 2.26f), 4.026f);
            yield return new WaitForSeconds(seconds);
            Instantiate(drip, randomize, Quaternion.Euler(0f, 0f, 0f), parent);
        }
        
        
    }
}
