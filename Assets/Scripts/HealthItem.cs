using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private GameObject player;
    private HealthManager hp;
    // Start is called before the first frame update
    void Awake()
    {
        player =  GameObject.Find("Mike Cousins");
        hp = GameObject.Find("Health Manager").GetComponent<HealthManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControllerJ player = other.gameObject.GetComponent<PlayerControllerJ>();
        if (player != null && hp.healthAmount < 100)
        {
            hp.Heal(10);
            Destroy(gameObject);
        }
        
    }
}
