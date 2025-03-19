using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject levelSelect;
    public GameObject startScreen;
    // Start is called before the first frame update
   
//    void Awake()
//    {
//       startScreen.SetActive(true);
//    }

   void Start()
   {
     //startScreen.SetActive(true);
   }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableOptions()
    {
        optionsMenu.SetActive(true);
        Debug.Log("Enabled");
    }

   public void DisableOptions()
    {
        optionsMenu.SetActive(false);
        Debug.Log("Disabled");
    }

    public void DisableMain()
    {
        mainMenu.SetActive(false);
        Debug.Log("Disabled");
    }

       public void EnableMain()
    {
        mainMenu.SetActive(true);
        Debug.Log("Enabled");

    }

     public void DisableLevels()
    {
        levelSelect.SetActive(false);
        Debug.Log("Disabled");
    }

       public void EnableLevels()
    {
        levelSelect.SetActive(true);
        Debug.Log("Enabled");
    }
}