using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOnCollision : MonoBehaviour
{

    public int maxHealth;
    int CurrentHealth;
    float Invicibletimer = 2.0f;
    public bool Invic;
    SpriteRenderer rend;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Invic)
            {
            rend.color = Color.red;
            Invicibletimer -= Time.deltaTime;
          

            if(Invicibletimer < 0 )
            {
            Invic = false;
            rend.color = Color.white;
            }
 }
    }

    public void ChangeHealth(int amount)
    {
        if (Invic)
            return;
       
        Invic = true;
        Invicibletimer = 2.0f;
       
       
           
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount,0,maxHealth);
        Debug.Log(CurrentHealth+ "/" +maxHealth);
    }
}
