using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    protected Transform player;
    protected float moveSpeed = 3;
    public LayerMask detect;
    private HealthManager hp;

    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 direction = player.position - transform.position;
        hp = GameObject.Find("Health Manager").GetComponent<HealthManager>(); 
        StartCoroutine(SelfDestruct());
    }
    protected virtual void Update()
    {
        if (player == null)
            return;

            Vector2 direction = (player.position - transform.position).normalized;
            
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
     void OnCollisionEnter2D(Collision2D other)
      {
        Destroy(gameObject);
        Vector2 direction = player.transform.position - transform.position;

        if(other.gameObject.tag.Equals("Player") == true )
        {
        hp.TakeDamage(20);
        }
      }
    IEnumerator SelfDestruct()
    {
    yield return new WaitForSeconds(2.5f);
    Destroy(gameObject);
    }
}