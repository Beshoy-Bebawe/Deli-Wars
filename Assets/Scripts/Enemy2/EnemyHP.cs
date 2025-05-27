using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public EnemyHealth Enemy;
    SpriteRenderer rend;
    int currentHealth;
    private int health;
    float kbTime = 4f;
    public bool canKnock = true;
    public bool knocked;
    float kbPow = 6f;
    float kbCD = 1f;
    bool Invic = false;
    // Start is called before the first frame update
    void Start()
    {
        health = Enemy.health;
        rend = GetComponent<SpriteRenderer>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void TakeDamage(int damage) 
    {
        if (knocked)
        {
        currentHealth = Mathf.Clamp(currentHealth + damage,0,health);
        Debug.Log(currentHealth + "/" + health);

        if (currentHealth <= 0)
        {
            Die();
        }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public IEnumerator Knockback(Vector2 direction,Rigidbody2D rb)
    {
        canKnock = false;
        knocked = true;
        rb.velocity = -direction * kbPow;
        rend.color = Color.red;
        yield return new WaitForSeconds(.25f);
        knocked = false;
        rend.color = Color.white;
        rb.velocity  = Vector2.zero;
        yield return new WaitForSeconds(kbCD);
        canKnock = true;


    }
}
