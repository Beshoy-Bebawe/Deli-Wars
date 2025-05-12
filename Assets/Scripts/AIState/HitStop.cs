using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitStop : MonoBehaviour
{
   
   bool waiting;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
       
        //To call Hitstop Use
        //Call the object and use .Stop(float value);
       
        //Problem with this code is that Hitstop doesn't stop time as object is being hit
    }
    public void Stop(float duration)
    {
        if(waiting)
            return;
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }
    IEnumerator Wait(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
    }
}
