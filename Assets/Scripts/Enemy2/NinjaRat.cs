using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NinjaRat : MonoBehaviour
{
    public ScriptObj Rat;
    public GameObject player;
    public GameObject enemy;
    private int speed;
    private int strength;
    private float distanceBetween;
    bool LOS = false;
    float distance;
    float timer = 4;
    public int Xdirection;
    Animator anim;
    Rigidbody2D rb;
    public LayerMask detect;
    PlayerDamTest playerD;
    public Vector2 direction;
    SpriteRenderer rend;
    float kbTime = 4f;
    public bool canKnock = true;
    public bool knocked;
    float kbPow = 6f;
    float kbCD = 1f;
    public bool Invic = false;
    // Start is called before the first frame update
    void Awake()
    {
        speed = Rat.speed;
        strength = Rat.strength;
        distanceBetween = Rat.distanceBetween;
        Debug.Log(speed + " " + strength);
        rend = GetComponent<SpriteRenderer>();
        rb = enemy.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {

        if (knocked)
        {
            return;
        }   
        if(player!= null)
        {
        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        if ((distance< distanceBetween) && (LOS))
        {
            rb.position = Vector2.MoveTowards(transform.position, player.transform.position,speed * 3 * Time.deltaTime);
            if (transform.position.x > player.transform.position.x - transform.position.x )
                {
                    anim.SetBool("Direction", true);
                }
                else
                {
                    anim.SetBool("Direction", false);
                }
        }
        }
        // else
        // {
        //    timer -= Time.deltaTime;
        // if (timer <= 0)
        // {
        //     Xdirection = Random.Range(-1,2);
        //     timer = 3;
        // }
        // if (Xdirection == -1 && timer !=0)
        // {
            
        //     rb.velocity = Vector2.left * speed;
        //     anim.SetBool("Direction",true);
        // }
        // else if (Xdirection ==1 && timer !=0)
        // {
            
        //     rb.velocity = Vector2.right * speed;
        //     anim.SetBool("Direction",false);
        // }
        // else
        // {
        // }
        // }
    }
      void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,distanceBetween);
    }
    void FixedUpdate() 
    {
        // Calculate direction from this object to the playerw
        if(player!= null)
        {
        Vector2 direction = player.transform.position - transform.position;
        // Cast the ray toward the player, using the inverse of detect layermask
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, ~detect);
        if (ray.collider != null)
        {
            LOS = ray.collider.gameObject.CompareTag("Player");
    
            if (ray.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position, direction, Color.blue);
             
            }
            else
            {
                Debug.DrawRay(transform.position, direction, Color.red);
            }
        }
        }
    }
    
    void OnCollisionStay2D(Collision2D other)
    {
        playerD = other.gameObject.GetComponent<PlayerDamTest>();
        Vector2 direction = transform.position - player.transform.position ;
        
        if ((playerD != null)  && playerD.Invic == false )
        {
            FindObjectOfType<HitStop>().Stop(0.2f);
            playerD.ChangeHealth(-2);
            StartCoroutine(HitStop());
        }
    }
    IEnumerator HitStop()
    {
        while(Time.timeScale != 1.0f)
        yield return null;
        if(playerD!= null)
        {
        StartCoroutine(playerD.Knockback(direction));
        }
    }

    public void EnemyDamaged()
    {
        EnemyHP t = GetComponent<EnemyHP>();
        StartCoroutine(t.Knockback(direction,rb));
        t.TakeDamage(-4);
    }
    
    

   

}

    


    

