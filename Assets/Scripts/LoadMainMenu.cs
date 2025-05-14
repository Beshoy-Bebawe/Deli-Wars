using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
   void Awake()
   {
      LoadNewScene();
   }
   public void LoadNewScene()
   {
    SceneManager.LoadScene("main menu",LoadSceneMode.Additive);
   }
}
