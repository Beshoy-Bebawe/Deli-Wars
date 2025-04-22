using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool isHit = false;
    public Transform[] AtkPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    PlayerControllerAnim Anim;
    float hitTimer;
    float timer = 1;
    Vector2 lookDirection;

    int currentLookDirection;

    // Start is called before the first frame update
    void Awake()
    {
       Anim = GetComponent<PlayerControllerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Anim.lookDirection;

        if (lookDirection == Vector2.down)
        {
            currentLookDirection = 0;
        }
        else if (lookDirection == Vector2.right)
        {
            currentLookDirection = 1;
        }
        else if (lookDirection == Vector2.left)
        {
            currentLookDirection = 2;
        }
        else if (lookDirection == Vector2.up)
        {
            currentLookDirection = 3;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            Punch();
        }
    }

    void Punch()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AtkPoint[currentLookDirection].position,attackRange,enemyLayers);
    
        //Detect Enemy
        //Damage Enemy

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (AtkPoint == null)
        return;
        
        Gizmos.DrawWireSphere(AtkPoint[currentLookDirection].position, attackRange);
    }

     
}
