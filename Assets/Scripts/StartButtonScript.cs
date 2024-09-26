using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartButtonScript : MonoBehaviour

{
    private Button button;
    //[SerializeField] string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScenes( [SerializeField] string sceneName)
    {
       SceneManager.LoadScene(sceneName);

    }
}
