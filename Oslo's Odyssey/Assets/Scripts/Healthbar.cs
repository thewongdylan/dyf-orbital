using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private ObjectLife objectLife;
    private float startingHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    // Start is called before the first frame update
    private void Start()
    {
        startingHealth = objectLife.startingHealth;
        totalHealthbar.fillAmount = objectLife.currentHealth / startingHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        currentHealthbar.fillAmount = objectLife.currentHealth / startingHealth;
    }
}
