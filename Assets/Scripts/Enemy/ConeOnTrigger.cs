using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyAI enemyAi;
 
   
    void OnTriggerEnter2D(Collider2D o)
    {
        
        if (o.gameObject.tag == "Player")
        {
            enemyAi.inViewCone = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D o)
    {
 
 
        if (o.gameObject.tag == "Player")
        {
            enemyAi.inViewCone = false;
        }
    }
}
