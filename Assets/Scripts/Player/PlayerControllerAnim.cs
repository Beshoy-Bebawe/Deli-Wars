using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAnim : MonoBehaviour
{
    [SerializeField] float blockWindow;
    public float speed = 10.0f;
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

    public bool canDash = true;
    bool dashing;
    float dashTime = .4f;
    float dashPow = 10f;
    float dashCD = 1f;
    TrailRenderer tr;
    BoxCollider2D dashThrough;
    bool atkInEffect;
    public bool atkTakeEffect;

    public bool isBlocking = false;
    public bool canBlock = true;

    // Start is called before the first frame update
    void Start()
    {
         rigidbody2d = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
         PlayerF = GetComponent<PlayerDamTest>();
         Attack =  GetComponent<PlayerCombat>();
         tr = GetComponent<TrailRenderer>();
         dashThrough = GetComponent<BoxCollider2D>();

         

    }

    // Update is called once per frame
    void Update()
    {
        
        

        
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
        BlockAnim();
            
            
         
          //Debug.Log(!PlayerF.knocked);
          //Debug.Log(isBlocking);
          //Debug.Log(canBlock);
    }
    void FixedUpdate()
    {

        if(PlayerF.knocked == false && isBlocking == false)
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

    void BlockAnim()
    {
        if(Input.GetKey(KeyCode.B) && canBlock == true )
        {
            isBlocking = true;
            PlayerF.Invic = true;
            StartCoroutine(BlockCD());
        }

        if(Input.GetKeyUp(KeyCode.B) && canBlock == true)
        {
            isBlocking = false;


        }
    }

    public IEnumerator Dash()
        {
        Physics2D.IgnoreLayerCollision(7,8,true);
        canDash = false;
        dashing = true;
        PlayerF.Invic = true;
        rigidbody2d.velocity = lookDirection * dashPow;
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
        rigidbody2d.velocity  = Vector2.zero;
        PlayerF.Invic = false;
        yield return new WaitForSeconds(dashCD);
        Debug.Log("Works Too");
        canDash = true;
        }


    public IEnumerator AttackWindow()
    {
        animator.SetBool("Attack", true);
        PlayerF.Invic = true;
        atkInEffect = true;
        atkTakeEffect = false;
        yield return new WaitForSeconds(0.5f);
        atkTakeEffect = true;
        Attack.Punch();
        yield return new WaitForSeconds(0.05f);
        animator.SetBool("Attack", false);
        atkTakeEffect = false;
        PlayerF.Invic = false;
        yield return new WaitForSeconds(1f);
        atkInEffect = false;
    }

    public IEnumerator BlockCD()
    {
        yield return new WaitForSeconds(blockWindow);
        canBlock = true;
        
    }  
   

    

        
    

}
