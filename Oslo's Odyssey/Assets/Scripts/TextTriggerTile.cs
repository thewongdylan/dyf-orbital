using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextTriggerTile : MonoBehaviour
{
    private string[] textList;
    [SerializeField] private int textIndex;
    [SerializeField] private TextMeshProUGUI instructionText;
    [SerializeField] private GameObject instructionDisplay;
    // [SerializeField] private float duration = 2f;

    private void Start()
    {
        instructionText.enabled = false;
        instructionDisplay.SetActive(false);
        textList = new string[] {
            "Use W,A,S,D to move around", //0
            "Use W to jump", //1
            "Walk over an orb to equip it", //2
            "Press SPACE to shoot", //3
            "Walk over the Air Orb to pick it up", //4
            "Press SPACE to activate its ability: Levitation", //5
            "While levitating, use W,A,S,D to move around" //6
        };
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            DisplayText();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DestroyText();
    }

    private void DisplayText()
    {
        Debug.Log("displaying text: " + textList[textIndex]);
        instructionText.enabled = true;
        instructionText.text = textList[textIndex];
        Debug.Log("text index " + textIndex + " displayed");
        instructionDisplay.SetActive(true);
        Debug.Log("text background enabled");
    }

    private void DestroyText()
    {
        instructionText.enabled = false;
        Debug.Log("text index " + textIndex + " removed");
        instructionDisplay.SetActive(false);
        Debug.Log("text background removed");
    }

    // private void DisplayText()
    // {
    //     textCurrentlyDisplayed = true;
    //     Debug.Log("displaying text: " + textList[textIndex]);
    //     instructionText.enabled = true;
    //     instructionText.text = textList[textIndex];
    //     Debug.Log("text index " + textIndex + " displayed");
    //     instructionDisplay.SetActive(true);
    //     Debug.Log("text background enabled");
    //     transform.GetComponent<BoxCollider2D>().enabled = false;
    //     Invoke("DestroyText", duration);
    // }

    // private void DestroyText()
    // {
    //     instructionText.enabled = false;
    //     Debug.Log("text index " + textIndex + " removed");
    //     instructionDisplay.SetActive(false);
    //     Debug.Log("text background removed");
    // }

    
}
