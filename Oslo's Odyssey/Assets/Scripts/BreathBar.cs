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
    [SerializeField] private OsloLife osloLife;

    // bar logic
    public Slider breathBarSlider;
    private GameObject oslo;
    private BreathBarController breathBarController;
    [SerializeField] private float breathDuration = 5f;
    public bool isBarFull;

    // Start is called before the first frame update
    void Start()
    {
        breathBarSlider = GetComponent<Slider>();
        oslo = GameObject.Find("Oslo");
        breathBarController = oslo.GetComponent<BreathBarController>();
        osloLife = oslo.GetComponent<OsloLife>();
        timer = 0f;
        isBarFull = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (breathBarController.isDrowning)
        {
            breathBarSlider.value -= Time.deltaTime / breathDuration;
            Debug.Log("breath bar depleting");
            if (breathBarSlider.value == 0)
            {
                isPlayerTakingDamage = true;
                Debug.Log("breath ran out, starting to take damage");
            }
            isBarFull = false;
        }
        else
        {
            if (breathBarSlider.value < 1)
            {
                breathBarSlider.value += Time.deltaTime / breathDuration;
                Debug.Log("breath bar refilling");
            }
            else if (breathBarSlider.value == 1)
            {
                isBarFull = true;
                Debug.Log("breath bar full");
            }
            isPlayerTakingDamage = false;
        }

        // damage logic
        if (isPlayerTakingDamage && timer >= damageInterval)
        {
            Debug.Log("taking damage from water");
            // if (osloLife != null)
            // {
            //     osloLife.TakeDamage(damage);
            //     Debug.Log("oslo life not null");
            // }
            osloLife.TakeDamage(damage);
            Debug.Log("taking damage from water");
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
}
