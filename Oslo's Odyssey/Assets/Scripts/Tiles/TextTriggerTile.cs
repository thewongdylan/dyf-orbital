using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTriggerTile : MonoBehaviour
{
    // private string[] textList;
    // [SerializeField] private int textIndex;
    [SerializeField] private TextMeshProUGUI instructionText;
    [SerializeField] private GameObject instructionDisplay;
    [SerializeField] private string textToDisplay;

    private void Start()
    {
        instructionText.enabled = false;
        instructionDisplay.SetActive(false);
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
        // Debug.Log("displaying text: " + textList[textIndex]);
        instructionText.enabled = true;
        instructionText.text = textToDisplay;
        // Debug.Log("text index " + textIndex + " displayed");
        instructionDisplay.SetActive(true);
        // Debug.Log("text background enabled");
    }

    private void DestroyText()
    {
        instructionText.enabled = false;
        // Debug.Log("text index " + textIndex + " removed");
        instructionDisplay.SetActive(false);
        // Debug.Log("text background removed");
    }    
}
