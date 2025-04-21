using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDamTest : MonoBehaviour
{
    public int maxHealth;
    int CurrentHealth;
    float Invicibletimer = 2.0f;
    float KBtime = 1.0f;
    public bool TrueKB;
    public bool Invic;
    public float mag = 5.0f;
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
                KBtime-= Time.deltaTime;
                if (KBtime < 0)
                {
                    TrueKB = false;
                }
               
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
        TrueKB = true;
        KBtime = 1.0f;
        Invicibletimer = 2.0f;
       
       
           
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount,0,maxHealth);
        Debug.Log(CurrentHealth+ "/" +maxHealth);
    }
    public void KB(Vector2 direction)
    {
        if (TrueKB)
        {
            rb.velocity = direction * mag;
        }
        else
        {
            mag = 0;
            rb.velocity = Vector2.zero;
        }
       
       
    }
}
