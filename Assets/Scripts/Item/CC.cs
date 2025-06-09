using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    public GameObject dialogPrompt;
   
    // Start is called before the first frame update
    void Start()
    {
        dialogPrompt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        dialogPrompt.gameObject.SetActive(true);
        Destroy(gameObject);
        
    }
}

