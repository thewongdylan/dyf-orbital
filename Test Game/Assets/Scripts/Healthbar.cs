using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private PlayerLife playerLife;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        totalHealthBar.fillAmount = playerLife.currentHealth / 3;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerLife.currentHealth / 3;
    }
}
