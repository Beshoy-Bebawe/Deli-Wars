using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJ : MonoBehaviour
{
    
    PlayerControllerJ player;
    Vector2 lookDirection = new Vector2(1,0);
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

    //Bun
    public GameObject bunPrefab;
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
         
         if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
         if (Input.GetKeyDown(KeyCode.M))
            {
                 ShootBuns();
            }
        if (currentPowerUp == PowerUpType.Speed)
           {
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
    //Honey Bun Shooter//
    public void ShootBuns()
    {
      if(gameManager.score > 0 )
        {
            Debug.Log("Stuff");
            GameObject bunObj = Instantiate(bunPrefab, rigidbody2d.position + lookDirection * 0.5f, Quaternion.identity);

            Bun projectile = bunObj.GetComponent<Bun>();
            projectile.Launch(lookDirection, 4);

            gameManager.UpdateScore(-1);
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