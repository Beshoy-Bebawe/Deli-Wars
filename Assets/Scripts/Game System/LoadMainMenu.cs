using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
   [SerializeField] string sceneName;
    // Assign your GameObject you want to move Scene in the Inspector
    public GameObject m_MyGameObject;
    AudioSource audioSource;
     public AudioClip BGTextClip;

   void Awake()
   {
      if (m_MyGameObject == null )
      {
         m_MyGameObject = GameObject.Find("AudioManager");
         audioSource = GetComponent<AudioSource>();
         StartCoroutine(LoadNewScene());
      } else if (m_MyGameObject != null)
      {
         StartCoroutine(LoadNewScene());
      } else 
      {
         StartCoroutine(LoadNewScene());
      }
      
   }
   public IEnumerator LoadNewScene()
   {
    // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        if (asyncLoad.isDone)
        {
          // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(m_MyGameObject, SceneManager.GetSceneByName(sceneName));

        if(currentScene.name == "Background Text")
        {

            audioSource.clip = BGTextClip;
            audioSource.Play();

        }
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
   }
}
