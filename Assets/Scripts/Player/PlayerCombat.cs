using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool isHit = false;
    public Transform[] AtkPoint;
    public GameObject[] AtkTrigger;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    PlayerControllerAnim Anim;
     NinjaRat Rat;
    float hitTimer;
    float timer = 1;
    Vector2 lookDirection;
    int currentLookDirection;


    // Start is called before the first frame update
    void Awake()
    {
       Anim = GetComponent<PlayerControllerAnim>();
       Rat =  GameObject.FindWithTag("Rat").GetComponent<NinjaRat>();
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

    
    }

    public void Punch()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AtkPoint[currentLookDirection].position,attackRange,enemyLayers);
        Debug.Log(hitEnemies);
        //Detect Enemy
        //Damage Enemy
        
        foreach(Collider2D enemy in hitEnemies)
        {
            if(Anim.atkTakeEffect = true)
            {
                Debug.Log("We hit " + enemy.name);
                NinjaRat enemyRat = enemy.GetComponent<NinjaRat>();
                Trash enemyTrash = enemy.GetComponent<Trash>();
                PidgeonMovement enemyBird = enemy.GetComponent<PidgeonMovement>();
                if (enemyRat != null)
                {
                    enemyRat.EnemyDamaged();
                }
                
                if (enemyTrash != null)
                {
                    enemyTrash.EnemyDamaged();
                }
                
                if (enemyBird != null)
                {
                    enemyBird.EnemyDamaged();
                }
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        if (AtkPoint == null)
        return;
        
        Gizmos.DrawWireSphere(AtkPoint[currentLookDirection].position, attackRange);
    }

    

     
}
