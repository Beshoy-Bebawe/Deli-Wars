using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    //public float speed = 3.0f;
    private Rigidbody2D enemyRb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
         enemyRb = GetComponent<Rigidbody2D>();
         player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    
    }


   // Damage////
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
       
    }

    
}
