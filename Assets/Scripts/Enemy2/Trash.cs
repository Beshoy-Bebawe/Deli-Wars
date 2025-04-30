using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameObject trashPrefab;
    //private float spawnRate = 1.0f;

   // public List<GameObject> targets; 
    //private bool act;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(SpawnTarget());
    }
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
      {
         Debug.Log("Cool");
           yield return new WaitForSeconds(1);
          // int index = Random.Range(0, targets.Count);
           //Instantiate(targets[index], transform.position, transform.rotation);
           Instantiate(trashPrefab, transform.position, trashPrefab.transform.rotation);
      }
}
