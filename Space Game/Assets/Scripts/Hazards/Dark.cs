using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Dark : MonoBehaviour
{

    [SerializeField]private Image image;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.transform.parent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator darken()
    {
        image.SetActive(true);
        yield return new WaitForSeconds(5f);
        image.SetEnabled(false);
    }
}
