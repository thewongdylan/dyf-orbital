using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsloHealthbar : MonoBehaviour
{
    [SerializeField] private OsloData osloData;
    [SerializeField] private Image totalHearts;
    [SerializeField] private Image[] osloCurrentHearts;
    private int numOfHearts;
    private int startingHealth;
    private int currentHealth;
    
    // Start is called before the first frame update
    public void Start()
    {
        startingHealth = osloData.startingHealth;
        currentHealth = osloData.currentHealth;
        numOfHearts = osloCurrentHearts.Length;
        SetHearts();
    }

    // Update is called once per frame
    public void Update()
    {
        currentHealth = osloData.currentHealth;
        SetHearts();
    }

    private void SetHearts()
    {
        int fullHearts = (int) Mathf.Ceil(currentHealth / 4);
        // Debug.Log("full hearts remaining: " + fullHearts);
        for (int i = 0; i < fullHearts; i++)
        {
            osloCurrentHearts[i].fillAmount = 1;
        }
        float remainderHeart = currentHealth % 4;
        // Debug.Log("last heart should be: " + remainderHeart / 4 + " filled");
        if (fullHearts < numOfHearts) 
        {
            osloCurrentHearts[fullHearts].fillAmount = remainderHeart / 4;
        }
    }
}
