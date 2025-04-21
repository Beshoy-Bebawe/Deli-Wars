using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIV2 : MonoBehaviour
{
    private Transform playerTransform;
    private Animator animator;
    private Transform[] waypoints = null;
    Vector3 direction;

    public bool chasing = false;
  
    private float distanceFromTarget;


    
    public float speed = 10;
    private int currentTarget;    
    // Start is called before the first frame update

     void Awake()
    {
        //Debug.Log("Currently" + chasing);
        // Get a reference to the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
 
        // Get a reference to the FSM (animator)
        animator = gameObject.GetComponent<Animator>();
 
        // Add all our waypoints into the waypoints array
        Transform point1 = GameObject.Find("p1").transform;
        Transform point2 = GameObject.Find("p2").transform;
        Transform point3 = GameObject.Find("p3").transform;
        Transform point4 = GameObject.Find("p4").transform;
        Transform point5 = GameObject.Find("p5").transform;
        waypoints = new Transform[5] {
            point1,
            point2,
            point3,
            point4,
            point5
        };
        
    }

    void Start()
    {
        
    }

    public void SetNextPoint()
    {
        // Pick a random waypoint 
        // But make sure it is not the same as the last one
        int nextPoint = -1;
 
        do
        {
           nextPoint =  Random.Range(0, waypoints.Length - 1);
        }
        while (nextPoint == currentTarget);
 
        currentTarget = nextPoint;
 
        // Load the direction of the next waypoint
        direction = waypoints[currentTarget].position - transform.position;
        rotateEnemy();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime, Space.World);
    }

     private void rotateEnemy()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        direction = direction.normalized;
    }
}
