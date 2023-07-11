using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public ObjectLife objectLife;
    private float startingHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;
    private float fraction;

    // Start is called before the first frame update
    public virtual void Start()
    {
        startingHealth = objectLife.startingHealth;
        totalHealthbar.fillAmount = objectLife.currentHealth / startingHealth;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        fraction = objectLife.currentHealth / startingHealth;
        //Debug.Log(fraction);
        currentHealthbar.fillAmount = fraction;
    }
}
