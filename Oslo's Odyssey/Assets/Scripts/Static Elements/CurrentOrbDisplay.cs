using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CurrentOrbDisplay : MonoBehaviour
{
    [SerializeField] private OsloData osloData;
    [SerializeField] private GameObject oslo;
    private OsloOrbs osloOrbs;
    [SerializeField] private TextMeshProUGUI currentOrbText;
    [SerializeField] private Image currentOrbImage;
    private Dictionary<string, Sprite> orbImageDict;
    [SerializeField] private Sprite airOrbSprite;
    [SerializeField] private Sprite earthOrbSprite;
    [SerializeField] private Sprite fireOrbSprite;
    [SerializeField] private Sprite waterOrbSprite;

    // Start is called before the first frame update
    void Start()
    {
        osloOrbs = oslo.GetComponent<OsloOrbs>();
        orbImageDict = new Dictionary<string, Sprite>(){
            {"Air Orb", airOrbSprite},
            {"Earth Orb", earthOrbSprite},
            {"Fire Orb", fireOrbSprite},
            {"Water Orb", waterOrbSprite}
        };
        
        if (osloOrbs.NoOrbEquipped())
        {
            currentOrbImage.enabled = false;
            // currentOrbText.text = "No Orb Equipped";
        }
        else
        {
            currentOrbText.text = "Currently\nEquipped:";
            currentOrbImage.enabled = true;
            currentOrbImage.sprite = orbImageDict[osloData.equippedOrbType];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (osloOrbs.NoOrbEquipped())
        {
            // currentOrbText.text = "No Orb Equipped";
        }
        else
        {
            currentOrbText.text = "Currently\nEquipped:";
            currentOrbImage.enabled = true;
            currentOrbImage.sprite = orbImageDict[osloData.equippedOrbType];
        }
    }
}
