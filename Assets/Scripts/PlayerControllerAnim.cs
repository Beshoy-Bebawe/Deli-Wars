using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAnim : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody2D rigidbody2d;
    Animator animator;
    float horizontal;
    float vertical;
    Vector2 lookDirection = new Vector2(1,0);
    bool startedMoving;
    bool isIdle;
    bool Spraying;
    

    // Start is called before the first frame update
    void Start()
    {
         rigidbody2d = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);

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

            if (Input.GetKey(KeyCode.C))
            {
                animator.SetBool("Spraying", true);
                Debug.Log("Spray");
            }
            else
            {
                animator.SetBool("Spraying", false);
                 
            }
        
          
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

}
