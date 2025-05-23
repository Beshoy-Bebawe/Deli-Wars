using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bun : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public LayerMask detect;
void Awake()
{
    rigidbody2d = GetComponent<Rigidbody2D>();
    StartCoroutine(SelfDestruct());
}
void Update()
{
    if(transform.position.magnitude > 1000.0f)
    {
        Destroy(gameObject);
    }
}

public void Launch(Vector2 direction, float force)
{
    rigidbody2d.velocity = direction * force; 
}
void OnCollisionEnter2D(Collision2D other)
{ 
    Destroy(gameObject);
}
IEnumerator SelfDestruct()
    {
    yield return new WaitForSeconds(5f);
    Destroy(gameObject);
    }
}