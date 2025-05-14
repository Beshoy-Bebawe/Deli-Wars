using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamTest : MonoBehaviour
{
    public int maxHealth;
    int CurrentHealth;

    public float speed = 10.0f;
    float hori;
    float vert;


  


    float kbTime = 4f;
    public bool canKnock = true;
    public bool knocked;
    float kbPow = 4f;
    float kbCD = 1f;

    public float Invicibletimer = 2.0f;
    public bool Invic = false;
    public bool wasHit = false;


    SpriteRenderer rend;
    
    public NinjaRat Rat;
    PlayerControllerAnim Pdirect;
    


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
        

        Invic = true;
        Invicibletimer = .5f;



        CurrentHealth = Mathf.Clamp(CurrentHealth + amount,0,maxHealth);
        Debug.Log(CurrentHealth+ "/" +maxHealth);

        if (CurrentHealth <= 0)
        {
          Destroy(gameObject);
        }
        
    }

    public IEnumerator Knockback()
    {
        canKnock = false;
        knocked = true;
        Pdirect.rigidbody2d.velocity = Rat.direction * kbPow*4;
        Invic = true;
        rend.color = Color.red;
        yield return new WaitForSeconds(.25f);
        knocked = false;
        rend.color = Color.white;
        Pdirect.rigidbody2d.velocity  = Vector2.zero;
        yield return new WaitForSeconds(.75f);
        Invic = false;
        yield return new WaitForSeconds(kbCD);
        canKnock = true;


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
