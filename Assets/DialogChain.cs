using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogChain : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject dialogBox;
    public GameObject dialogPrompt;
    private bool dialogTrigger;

    private int index;
    // Start is called before the first frame update
    void Awake()
    {
        textComponent.text= string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogTrigger)
        {
            dialogPrompt.gameObject.SetActive(true);
        }
        else
        {
            dialogPrompt.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.X) && dialogTrigger)
        { 
            dialogBox.gameObject.SetActive(true);
            if (textComponent.text == lines[index])
            { 
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    
    void StartDialogue()
    {
         index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
       
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogBox.gameObject.SetActive(false);

        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") )
        {
            dialogTrigger = true;
            index = 0;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") )
        {
            dialogTrigger = false;
            dialogBox.gameObject.SetActive(false);
            index = 1;
            StopAllCoroutines();
        }
    }

}
