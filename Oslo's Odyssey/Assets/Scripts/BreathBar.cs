using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathBar : MonoBehaviour
{
    // damage logic fields
    [SerializeField] private float damage = 1f;
    [SerializeField] private float damageInterval = 1f;
    private float timer;
    private bool isPlayerTakingDamage = false;
    [SerializeField] OsloLife osloLife;

    // bar logic
    public Slider breathBarSlider;
    private GameObject oslo;
    [SerializeField] private float breathDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        breathBarSlider = GetComponent<Slider>();
        oslo = GameObject.Find("Oslo");
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (WaterTile.inWater)
        {
            breathBarSlider.value -= Time.deltaTime / breathDuration;
            //Debug.Log("deplete");
            if (breathBarSlider.value == 0)
            {
                isPlayerTakingDamage = true;
            }
        }
        else
        {
            breathBarSlider.value += Time.deltaTime / breathDuration;
            isPlayerTakingDamage = false;
        }
        // damage logic
        if (isPlayerTakingDamage && timer >= damageInterval)
        {
            Debug.Log("taking damage");
            if (osloLife != null)
            {
                osloLife.TakeDamage(damage);
                Debug.Log("oslo life not null");
            }
            
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
}
