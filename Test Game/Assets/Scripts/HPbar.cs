using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField] private EnemyLife enemyLife;
    [SerializeField] private Image totalHPBar;
    [SerializeField] private Image currentHPBar;

    // Start is called before the first frame update
    void Start()
    {
        totalHPBar.fillAmount = enemyLife.currentHealth / 5;
    }

    // Update is called once per frame
    void Update()
    {
        currentHPBar.fillAmount = enemyLife.currentHealth / 5;
    }
}
