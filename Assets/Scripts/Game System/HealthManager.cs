using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    
    private GameObject player;
    public Image healthBar;
    public float healthAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.Find("Mike Cousin(Amir)");
    }
    // Update is called once per frame
    void Update()
    {
      // if(healthAmount <= 0)
      // {
      //   Debug.Log("GAME OVER");
      //   // Destroy(player);
      //   // Time.timeScale = 0;
      // }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
