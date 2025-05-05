using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
     public GameObject trashPrefab;
     private GameObject player;

     public float distanceBetween;
     public LayerMask detect;
     
     bool LOS = false;
     float distance;

   //public List<GameObject> targets; 
    void Awake()
    {
      InvokeRepeating("TrashLaunch", 0.0f, 1.3f);
      player =  GameObject.Find("Mike Cousins");

    }
    // Update is called once per frame
    void Update()
    {

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
         Debug.Log("Cool");
        Instantiate(trashPrefab, transform.position, trashPrefab.transform.rotation);
      }

      private void TrashLaunch()
      {
        if(LOS && (distance < distanceBetween))
        {
        Debug.Log("Cool");
        Instantiate(trashPrefab, transform.position, trashPrefab.transform.rotation);
        }
      }

}
