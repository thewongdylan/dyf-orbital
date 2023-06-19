using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour
{
    public Slider abilityBarSlider;
    private LevitationAbility levitationAbility;

    private void Start()
    {
        abilityBarSlider = GetComponent<Slider>();
        levitationAbility = transform.parent.transform.parent.GetComponent<LevitationAbility>(); // get levitation from oslo game obj
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
