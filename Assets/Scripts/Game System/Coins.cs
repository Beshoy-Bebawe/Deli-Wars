using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    private GameManager gameManager;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
