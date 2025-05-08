using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 4.0f;
    public float yOffset = 1.0f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {   if(target != null)
        {   
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -10.0f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        }      
    }
}
