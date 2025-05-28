using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PidgeonMovement : MonoBehaviour
// {
//     public GameObject[] points;
//     Rigidbody2D rb;
//     int point;
//     public float speed;
//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         CyclePoint();
//     }

//     void CyclePoint()
//     {
//         point = 0;
//         while(point < 5)
//         {
//             transform.position = Vector2.MoveTowards(rb.position, points[point].transform.position, speed * Time.deltaTime);
//             StartCoroutine(Timer(20));
//        
//            
//             Debug.Log(point);
//         }
//     }

//         IEnumerator Timer(float duration)
//         {
//         yield return new WaitForSecondsRealtime(duration);
//         point++;
//         }
// }
