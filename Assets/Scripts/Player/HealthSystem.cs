using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float healthAmount = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(healthAmount <= 0)
        {
            Debug.Log("Dead");
            healthAmount = 100;
        }
    }
    public void TakeDamage(float damagePoints)
    {
        healthAmount -= damagePoints;
    }
    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
    }
}
