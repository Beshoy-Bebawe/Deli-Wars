using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
     public GameObject trashPrefab;
     private GameObject player;

     public float distanceBetween;
     public LayerMask detect;
     
    public Vector2 direction;
    Rigidbody2D rb;

    Animator animator;

     bool LOS = false;
     float distance;

   //public List<GameObject> targets; 
    void Awake()
    {
      animator = GetComponent<Animator>();
      player =  GameObject.Find("Mike Cousin(Amir)");
      rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        direction = player.transform.position - transform.position;
        direction.Normalize();
       if(LOS && (distance < distanceBetween))
      {
       StartCoroutine(timer());
      }
      
    }
     void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        // Calculate direction from this object to the player
        Vector2 Tdirection = player.transform.position - transform.position;
        // Cast the ray toward the player, using the inverse of detect layermask
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Tdirection, Mathf.Infinity, ~detect);
        if (ray.collider != null)
        {
            LOS = ray.collider.gameObject.CompareTag("Player");
          
            if (ray.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position, Tdirection, Color.green);
                
            }
            else
            {
                Debug.DrawRay(transform.position, Tdirection, Color.red);
            }
        }

        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, distanceBetween);
    }
    void SpawnTarget()
      {
        Instantiate(trashPrefab, transform.position, trashPrefab.transform.rotation);
      }

    private void TrashLaunch()
    {
      if(LOS && (distance < distanceBetween))
      {
       animator.SetBool("Atk" , true);  
      
      }
      else
      {
        animator.SetBool("Atk" , false);
      }
    }

       public void EnemyDamaged()
    {
        EnemyHP r = GetComponent<EnemyHP>();
        StartCoroutine(r.Knockback(direction,rb));
        r.TakeDamage(-4);
    }
    IEnumerator timer()
    {
      yield return new WaitForSeconds(1f);
      animator.SetTrigger("Atk 0");
    }

}
