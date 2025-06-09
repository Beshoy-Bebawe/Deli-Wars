using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    Scene currentScene;
    public AudioClip BGTextClip;
//     public AudioClip Level1Clip;

//     // Start is called before the first frame update
    void Awake()
    {
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene();
        if (audioSource != null )
        {
            audioSource.clip = BGTextClip;
            audioSource.Play();
            DontDestroyOnLoad(gameObject);
            Debug.Log("found");
        }
        

    }

//     // Update is called once per frame
    void Update()
    {
//         Debug.Log(currentScene.name);
        if(currentScene.name == "Background Text")
        {

            

        }
//         if(currentScene.name == "Level 1")
//         {
//             audioSource.clip = Level1Clip;
//             audioSource.Play();

        }
//     }
}
