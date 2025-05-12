using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Healing(20);
        }
         if(healthAmount <= 0)
        {
            Debug.Log("Dead");
        }
    }
    public void TakeDamage(float damagePoints)
    {
        healthAmount -= damagePoints;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
