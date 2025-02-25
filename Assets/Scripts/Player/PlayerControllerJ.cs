using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJ : MonoBehaviour
{
    private GameManager gameManager;

    //Animator 
    Animator animator;


    //Powerup
    public bool hasPowerup = false;
    public PowerUpType currentPowerUp = PowerUpType.None;
    private Coroutine powerupCountdown;
    public GameObject powerupIndicator;


    //Movement
    float horizontal;
    float vertical;
    public float speed = 10.0f;

    //Health
    //public int health { get { return currentHealth; }}
    //int currentHealth;
// private int maxHealth = 3;
    
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
         //coneZone = GetComponent<EnemyAI> ();

         //Health sets current hp to max hp 
         //currentHealth = maxHealth;
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

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Enemy")) 
        {
            gameManager.UpdateLives(1);
        } 
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);

            if(powerupCountdown != null)
            {
                StopCoroutine(powerupCountdown);
            }
            powerupCountdown = StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false; 
        currentPowerUp = PowerUpType.None;
        powerupIndicator.gameObject.SetActive(false);
    }

    
}