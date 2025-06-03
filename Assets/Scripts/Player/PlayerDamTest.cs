using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamTest : MonoBehaviour
{
    public int maxHealth;
    int CurrentHealth;
    

    public int health
    {
        get {return CurrentHealth; }
    }
    


  


    float kbTime = 4f;
    public bool canKnock = true;
    public bool knocked = false;
    float kbPow = 5f;
    float kbCD = 1f;

    public float Invicibletimer = 2.0f;
    public bool Invic = false;
    public bool wasHit = false;


    SpriteRenderer rend;
    
    PlayerControllerAnim Pdirect;

    Projectile proj;

    NinjaRat Rat;
    


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
       
        rend = GetComponent<SpriteRenderer>();
        
        Pdirect = GetComponent<PlayerControllerAnim>();
    }

    // Update is called once per frame
    void Update()
    {

        

            

           


    }

    public void ChangeHealth(int amount)
    {
        if (Invic)
            return;
        wasHit = true;
        

        



        CurrentHealth = Mathf.Clamp(CurrentHealth + amount,0,maxHealth);
        Debug.Log(CurrentHealth+ "/" +maxHealth);

        if (CurrentHealth <= 0)
        {
          Destroy(gameObject);
          
        }
        
    }

    public IEnumerator Knockback(Vector2 direction)
    {
        canKnock = false;
        knocked = true;
        Pdirect.rigidbody2d.velocity = direction * kbPow;
        Invic = true;
        
        rend.color = Color.red;
        Debug.Log("1");
        yield return new WaitForSeconds(.25f);
        Debug.Log("Invic " + Invic);
        knocked = false;
        rend.color = Color.white;
        Pdirect.rigidbody2d.velocity  = Vector2.zero;
        yield return new WaitForSeconds(2f);
        Invic = false;
        Debug.Log("2");
        yield return new WaitForSeconds(kbCD);
        canKnock = true;


    }

     void OnCollisionEnter2D(Collision2D other)
     {
        proj = other.gameObject.GetComponent<Projectile>();
        Rat = other.gameObject.GetComponent<NinjaRat>();
        if(other.gameObject == proj.gameObject && Invic == false )
        {
            StartCoroutine(Knockback(proj.knockfrom));
        }
   
        
     }


    // private IEnumerator Teleport()
    // {
    //     canDash = false;
    //     dashing = true;
    //     transform.position = new Vector2(transform.position.x + 10,transform.position.y);
    //     Debug.Log("Works");
    //     dashing = false;
    //     rb.velocity  = Vector2.zero;
    //     yield return new WaitForSeconds(0.5f);
    //     Debug.Log("Works Too");
    //     canDash = true;


    // }
}
