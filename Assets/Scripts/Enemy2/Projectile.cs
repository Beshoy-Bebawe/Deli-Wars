using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    protected Transform player;
    GameObject playerK;
    protected float moveSpeed = 3;
    PlayerDamTest playerD;
    public Vector2 knockfrom;
    public LayerMask detect;
    bool comp;
    SpriteRenderer obj;

    Coroutine Knockback;
    protected virtual void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerK = GameObject.Find("Mike Cousin(Amir)");
        Vector2 direction = player.position - transform.position;
        obj = GetComponent<SpriteRenderer>();
        // obj.enabled = true;
        Destroy(gameObject, 2f);
    }

    protected virtual void Update()
    {
        if (player == null)
            return;

            knockfrom = playerK.transform.position - transform.position;
            knockfrom.Normalize();
            Vector2 direction = (player.position - transform.position).normalized;
            
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

     void OnCollisionEnter2D(Collision2D other)
    {
         playerD = other.gameObject.GetComponent<PlayerDamTest>();


         
            Destroy(gameObject);

        if ((playerD != null)  && (playerD.Invic == false) )
        {
            FindObjectOfType<HitStop>().Stop(0.2f);
            playerD.ChangeHealth(-1);
        }
        else if (playerD.Invic == true)
        {
            Debug.Log("Player invincible");
        }
      
        
    }

    //  IEnumerator HitStop()
    // {
    //     while(Time.timeScale != 1.0f)
    //     yield return null;
    //     if(playerD != null)
    //     {
    //         if(Knockback != null)
    //         {
    //             StopCoroutine("playerD.Knockback");
    //         }
    //     }
    //     Knockback = StartCoroutine(playerD.Knockback(knockfrom));
    //     yield return new WaitForSeconds(1f);
    //     // Destroy(gameObject);
        
    // }


}

