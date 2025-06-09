using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2Path : MonoBehaviour
{
    public GameObject dialogPrompt;
    private bool dialogTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(dialogTrigger)
        {
            dialogPrompt.gameObject.SetActive(true);
            Debug.Log("E");
        }
        else
        {
            dialogPrompt.gameObject.SetActive(false);
        }
    }

      void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") )
        {
            dialogTrigger = true;
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") )
        {
            dialogTrigger = false;
        }
    }
}
