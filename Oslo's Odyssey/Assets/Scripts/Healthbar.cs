using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public ObjectLife objectLife;
    private int startingHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    // Start is called before the first frame update
    public virtual void Start()
    {
        startingHealth = objectLife.startingHealth;
        totalHealthbar.fillAmount = objectLife.currentHealth / startingHealth;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        currentHealthbar.fillAmount = objectLife.currentHealth / startingHealth;
    }
}
