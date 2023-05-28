using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsloHealthbar : MonoBehaviour
{
    [SerializeField] private OsloLife osloLife;
    private float startingHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    // Start is called before the first frame update
    void Start()
    {
        startingHealth = osloLife.startingHealth;
        totalHealthbar.fillAmount = osloLife.currentHealth / startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthbar.fillAmount = osloLife.currentHealth / startingHealth;
    }
}
