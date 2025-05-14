using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Awake()
    {
        pauseScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            if(isPaused)
            {
                Time.timeScale = 0;
                pauseScreen.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseScreen.gameObject.SetActive(false);
            }
        }
    }

    public void RestartLevel([SerializeField] string sceneName)
    {
        if(Time.timeScale ==0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToMainMenu([SerializeField] string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}