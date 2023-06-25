using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour
{
    public Slider abilityBarSlider;
    private LevitationAbility levitationAbility;
    private GameObject oslo;

    private void Start()
    {
        // DontDestroyOnLoad(gameObject);
        abilityBarSlider = GetComponent<Slider>();
        oslo = GameObject.Find("Oslo");
        levitationAbility = oslo.GetComponent<LevitationAbility>(); // get levitation from oslo game obj
        
    }

    private void Update()
    {
        if (levitationAbility.isLevitating)
        {
            abilityBarSlider.value -= Time.deltaTime / levitationAbility.levitationDuration;
            //Debug.Log("deplete");
        }
        else
        {
            abilityBarSlider.value += Time.deltaTime / levitationAbility.levitationDuration;
            
        }

        // Clamp the fill value between 0 and 1
        abilityBarSlider.value = Mathf.Clamp01(abilityBarSlider.value);
    }
}
