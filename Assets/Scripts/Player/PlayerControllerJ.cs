using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJ : MonoBehaviour
{
    //Animator 
    Animator animator;

    //Movement
    float horizontal;
    float vertical;
    public float speed = 10.0f;

    //Health
    public int health { get { return currentHealth; }}
    int currentHealth;
    private int maxHealth = 3;
    
    //GameComponent 
    Rigidbody2D rigidbody2d;

    public float timeInvincible;
    bool isInvincible;
    float invincibleTimer;




    // Start is called before the first frame update
    void Start()
    {
         rigidbody2d = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();

         //Health sets current hp to max hp 
         currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
          Vector2 move = new Vector2(horizontal, vertical);

          if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
            Debug.Log("Works"); 
            //PlaySound(hitSound);
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    

}
