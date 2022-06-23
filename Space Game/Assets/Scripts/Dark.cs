using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dark : MonoBehaviour
{

    [SerializeField] private Sprite image;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.transform.parent);
        image = GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(Darken());
        }
    }

    IEnumerator Darken()
    {
        //image.enabled = true;
        yield return new WaitForSeconds(5f);
        //image.enabled = false;
    }
}