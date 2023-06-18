using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CurrentOrbDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentOrbText;
    [SerializeField] private Image currentOrbImage;
    [SerializeField] private GameObject oslo;
    private OsloOrbs osloOrbs;
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
            {"Air", airOrbSprite},
            {"Earth", earthOrbSprite},
            {"Fire", fireOrbSprite},
            {"Water", waterOrbSprite}
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (osloOrbs.NoOrbEquipped())
        {
            currentOrbText.text = "No Orb Equipped";
        }
        else
        {
            currentOrbText.text = "Currently\nEquipped:";
            currentOrbImage.sprite = orbImageDict[osloOrbs.equippedOrbType];
        }
    }
}
