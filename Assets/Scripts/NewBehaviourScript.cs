using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableOptions()
    {
        optionsMenu.SetActive(true);
    }

   public void DisableOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void DisableMain()
    {
        mainMenu.SetActive(false);
    }

       public void EnableMain()
    {
        mainMenu.SetActive(true);
    }
}