using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenu : MonoBehaviour
{
   void Awake()
   {
      LoadNewScene();
   }
   public void LoadNewScene()
   {
    UnityEngine.SceneManagement.SceneManager.LoadScene("main menu");
   }
}
