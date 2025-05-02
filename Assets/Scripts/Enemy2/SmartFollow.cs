using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SmartFollow : MonoBehaviour
{
    private GameObject player;
    bool LOS = false;
    private float speed = 4;
    public float distanceBetween;
    public Transform raycastOrigin; // Reference to the raycast origin point
    public LayerMask detect; // LayerMask for detection
 
    float distance;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        player =  GameObject.Find("Mike Cousins");
        rb = GetComponent<Rigidbody2D>();

        if (raycastOrigin == null)
            raycastOrigin = transform;
    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if ((distance < distanceBetween) && LOS )
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, distanceBetween);
    }
    void FixedUpdate()
    {
        // Calculate direction from this object to the player
        Vector2 direction = player.transform.position - raycastOrigin.position;
        // Cast the ray toward the player, using the inverse of detect layermask
        RaycastHit2D ray = Physics2D.Raycast(raycastOrigin.position, direction, Mathf.Infinity, ~detect);
        if (ray.collider != null)
        {
            
            LOS = ray.collider.gameObject.CompareTag("Player");
            if (ray.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawRay(raycastOrigin.position, direction, Color.blue);
            }
            else
            {
                Debug.DrawRay(raycastOrigin.position, direction, Color.red);
            }
        }
    }

}