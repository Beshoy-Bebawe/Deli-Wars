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
         //Debug.Log("Currently" + enemyAi.chasing);
            enemyAi.inViewCone = true;
            
            enemyAi.StartChasing();
            //enemyAi.ToggleWaiting();
        }
    }
    
    void OnTriggerExit2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            enemyAi.inViewCone = false;
            enemyAi.StopChasing();
            enemyAi.ToggleWaiting();
        }
    }
}