using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    protected Transform player;
    protected NavMeshAgent agent;
    protected float moveSpeed = 10;
   

    
    public LayerMask detect;
    bool LOS = false;

    protected virtual void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        // Configure NavMeshAgent for 2D
        Vector2 direction = player.position - transform.position;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = moveSpeed;
        // Additional NavMeshAgent settings
        
        

        agent.avoidancePriority = Random.Range(1, 100); // Randomize priority to avoid crowding
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance; // For better performance
        agent.radius = GetComponent<Collider2D>().bounds.extents.x; // Match collider size
    }

    

    protected virtual void Update()
    {
        if (player == null)
            return;
        if (agent.isOnNavMesh)
        {
            // Check if the destination is on the NavMesh
            NavMeshHit hit;
            // Try to find the nearest valid position on the NavMesh within 5 units of the player
            // Parameters:
            // - player.position: The target position to check
            // - hit: Stores the result of the sampling
            // - 5f: Maximum distance to check for a valid position
            // - NavMesh.AllAreas: Check all NavMesh areas (walkable surfaces)
            if (NavMesh.SamplePosition(player.position, out hit, 5f, NavMesh.AllAreas))
            {
                // If a valid position was found, set it as the agent's destination
                // This ensures the enemy only moves to valid locations on the NavMesh
                agent.SetDestination(hit.position);
            }
        }
        else
        {
            // Direct movement if NavMesh is not available
            Vector2 direction = (player.position - transform.position).normalized;
            
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            
        }
    }

    void FixedUpdate()
    {
        
    }

     void OnCollisionEnter2D(Collision2D other)
    {
         HurtOnCollision playerD = other.gameObject.GetComponent<HurtOnCollision>();
          Vector2 direction = player.transform.position - transform.position;

            Destroy(gameObject);

        if (playerD != null)
        {
          
            playerD.ChangeHealth(-1);
            
        }

    }
}
