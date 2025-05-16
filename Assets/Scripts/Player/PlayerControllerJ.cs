using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJ : MonoBehaviour
{
    
    PlayerControllerJ player;
    //Animator 
    Animator animator;

    //Powerup
    public bool hasPowerup = false;
    public PowerUpType currentPowerUp = PowerUpType.None;
    private Coroutine powerupCountdown;
    //public GameObject powerupIndicator;

    //Movement
    float horizontal;
    float vertical;
    private float speed;

    //GameComponent 
    Rigidbody2D rigidbody2d;

    //Coins
     private GameManager gameManager;
    public int pointValue;



    // Start is called before the first frame update
    void Start()
    {
         rigidbody2d = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
         gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
          Vector2 move = new Vector2(horizontal, vertical);
    
        if (currentPowerUp == PowerUpType.Speed){
            speed = 7.0f;
        }
        else{
            speed = 5.0f;
        }
        // if (currentPowerUp == PowerUpType.Defense)
        // {

        // }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Powerup") )
        {
            Debug.Log("powerup");
            hasPowerup = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            Destroy(other.gameObject);

            if(powerupCountdown != null)
            {
                StopCoroutine(powerupCountdown);
            }
            powerupCountdown = StartCoroutine(PowerupCountdownRoutine());
        }
        if(other.gameObject.CompareTag("Collect"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false; 
        currentPowerUp = PowerUpType.None;

    }
}