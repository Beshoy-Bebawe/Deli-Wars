using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    private bool isPaused;
    public GameObject deathScreen;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       deathScreen.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
       
         if (player == null) 
        {
            Debug.Log("Yes");
           ShowScreen();
        }
       
    }

    void ShowScreen()
    {
        deathScreen.gameObject.SetActive(true); 
    }
}
