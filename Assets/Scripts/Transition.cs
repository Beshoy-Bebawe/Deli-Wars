using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    public void ChangeSceneLevel2( [SerializeField] string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}