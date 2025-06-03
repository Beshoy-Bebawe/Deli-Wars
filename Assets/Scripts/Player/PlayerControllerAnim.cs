
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this for UI components

public class PlayerControllerAnim : MonoBehaviour
{
    public float speed = 4.0f;
    public Rigidbody2D rigidbody2d;
    Animator animator;
    float horizontal;
    float vertical;
    public Vector2 lookDirection = new Vector2(1,0);
    bool startedMoving;
    bool isIdle;

    PlayerDamTest PlayerF;
    PlayerCombat Attack;
    public Vector2 move;

    public GameObject bunPrefab;
    private GameManager gameManager;
    public int pointValue;

    public bool hasPowerup = false;
    public PowerUpType currentPowerUp = PowerUpType.None;
    private Coroutine powerupCountdown;

    public bool canDash = true;
    bool dashing;
    float dashTime = .4f;
    float dashPow = 15f;
    float dashCD = 2f;
    TrailRenderer tr;
    BoxCollider2D dashThrough;
    bool atkInEffect;
    public bool atkTakeEffect;
    bool cooldown;
    bool dashcooldown;
    bool projcooldown;
    // Add slider reference
    public Slider cooldownSlider;
    float cooldownTimer;
    float maxCooldownTime = 1f; // Total cooldown duration


    public Slider dashcooldownSlider;
    float dashmaxCooldownTime = 1f;
    float dashcooldownTimer;

    public Slider projcooldownSlider;
    float projmaxCooldownTime = 1f;
    float projcooldownTimer;

    public AudioClip punchSound;
    AudioSource audioSource;

    public bool canShoot = true;
    
    // Start is called before the first frame update
    void Start()
    {
         rigidbody2d = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
         PlayerF = GetComponent<PlayerDamTest>();
         Attack =  GetComponent<PlayerCombat>();
         tr = GetComponent<TrailRenderer>();
         dashThrough = GetComponent<BoxCollider2D>();
         gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
         audioSource = GetComponent<AudioSource>();
         

    }

    // Update is called once per frame
    void Update()
    {
        if (currentPowerUp == PowerUpType.Speed)
           {
            speed = 7.0f;
           }
        else{
            speed = 4.0f;
        }

        if (dashing)
        {
            return;
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        move = new Vector2(horizontal, vertical);

         if(Input.GetKeyUp(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

         if (Input.GetKeyDown(KeyCode.M) && canShoot)
            {
                 ShootBuns();
            }

        // Update slider during cooldown
        if (dashcooldown == true)
        {
            dashcooldownTimer += Time.deltaTime * (1f/dashCD);
            if (dashcooldownSlider != null)
            {
                dashcooldownSlider.value = dashcooldownTimer / dashmaxCooldownTime;
            }
        }

        if (cooldown == true)
        {
            cooldownTimer += Time.deltaTime * 4;
            if (cooldownSlider != null)
            {
                cooldownSlider.value = cooldownTimer / maxCooldownTime;
            }
        }

        if (projcooldown == true)
        {
            projcooldownTimer += Time.deltaTime * (1f/2f);
            if (projcooldownSlider != null)
            {
                projcooldownSlider.value = projcooldownTimer / projmaxCooldownTime;
            }
        }

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
                startedMoving = true;
                isIdle = false;
            }
            else if (Mathf.Approximately(move.x, 0.0f) || Mathf.Approximately(move.y, 0.0f))
            {
                isIdle = true;
                startedMoving = false;

            }
            if (startedMoving && !isIdle)
            {
               animator.SetBool("Moving", true);
            }
            else
            {
                animator.SetBool("Moving", false);

            }

            animator.SetFloat("Move X", lookDirection.x);
            animator.SetFloat("Move Y", lookDirection.y);

        PunchAnim();
    }
    
    void FixedUpdate()
    {
        if(!PlayerF.knocked)
        {
            if (dashing)
            {
                return;
            }

            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }
    }

    void PunchAnim()
    {
        if(Input.GetKeyDown(KeyCode.C) && atkInEffect == false )
        {
            StartCoroutine(AttackWindow());
        }
    }

    public IEnumerator Dash()
        {
        Physics2D.IgnoreLayerCollision(7,8,true);
        Physics2D.IgnoreLayerCollision(7,10,true);
        canDash = false;
        dashing = true;
        PlayerF.Invic = true;
        rigidbody2d.velocity = lookDirection * dashPow;
        
        // setting trail direction
        tr.emitting = true;
        if (lookDirection == Vector2.up)
        {
            tr.sortingOrder = 1;
        }
        else
        {
             tr.sortingOrder = -1;
        }
        yield return new WaitForSeconds(dashTime);
        Debug.Log("Works");
        dashing = false;
        tr.emitting = false;
        Physics2D.IgnoreLayerCollision(7,8,false);
        Physics2D.IgnoreLayerCollision(7,10,false);
        rigidbody2d.velocity  = Vector2.zero;
        PlayerF.Invic = false;
        dashcooldown = true;
        dashcooldownTimer = 0f;
        if (dashcooldownSlider != null)
        {
            dashcooldownSlider.value = 0f; // Start slider at 0
        }
        yield return new WaitForSeconds(dashCD);
        dashcooldown = false;
        if (dashcooldownSlider != null)
        {
            dashcooldownSlider.value = 1f; // Ensure slider reaches 1 when cooldown ends
        }
        Debug.Log("Works Too");
        canDash = true;
        }

    public IEnumerator AttackWindow()
    {
        animator.SetBool("Attack", true);
        PlayerF.Invic = true;
        atkInEffect = true;
        atkTakeEffect = false;
        audioSource.PlayOneShot(punchSound, 0.7f);
        yield return new WaitForSeconds(0.5f);
        atkTakeEffect = true;
        Attack.Punch();
        cooldown = true;
        cooldownTimer = 0f; // Reset timer when cooldown starts
        if (cooldownSlider != null)
        {
            Debug.Log("Here");
            cooldownSlider.value = 0f; // Start slider at 0
        }
        yield return new WaitForSeconds(0.05f);
        animator.SetBool("Attack", false);
        atkTakeEffect = false;
        yield return new WaitForSeconds(0.25f);
        cooldown = false;
        if (cooldownSlider != null)
        {
            cooldownSlider.value = 1f; // Ensure slider reaches 1 when cooldown ends
        }
        PlayerF.Invic = false;
        atkInEffect = false;
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

    public void ShootBuns()
    {
      
        StartCoroutine(ShootingCooldown());
    }

     IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false; 
        currentPowerUp = PowerUpType.None;

    }
    IEnumerator ShootingCooldown()
    {
        if(gameManager.score > 0)
        {
            Debug.Log("Stuff");
            GameObject bunObj = Instantiate(bunPrefab, rigidbody2d.position + lookDirection * 0.5f, Quaternion.identity);

            Bun projectile = bunObj.GetComponent<Bun>();
            
            projectile.Launch(lookDirection, 10);
            gameManager.UpdateScore(-1);
            canShoot = false;
            projcooldown = true;
            projcooldownTimer = 0f; // Reset timer when cooldown starts
            if (projcooldownSlider != null)
            {
                projcooldownSlider.value = 0f; // Start slider at 0
            }
            yield return new WaitForSeconds(2);
            projcooldown = false;
            if (projcooldownSlider != null)
            {
                projcooldownSlider.value = 1f; // Start slider at 0
            }
            canShoot = true;
        }
        
    }
}
