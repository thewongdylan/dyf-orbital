using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] private EnemyLife enemyLife;
    private float startingHealth;
    [SerializeField] private Image totalHealthbar;
    [SerializeField] private Image currentHealthbar;

    // Start is called before the first frame update
    void Start()
    {
        startingHealth = enemyLife.startingHealth;
        totalHealthbar.fillAmount = enemyLife.currentHealth / startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthbar.fillAmount = enemyLife.currentHealth / startingHealth;
    }
}
