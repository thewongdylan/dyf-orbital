using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AvailableOrbDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI availableOrbText;
    private List<GameObject> availableOrbs;
    [SerializeField] private Image[] availableOrbImages;
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
            {"Air Orb", airOrbSprite},
            {"Earth Orb", earthOrbSprite},
            {"Fire Orb", fireOrbSprite},
            {"Water Orb", waterOrbSprite}
        };
        availableOrbs = osloOrbs.availableOrbs;
        foreach (Image img in availableOrbImages)
        {
            img.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        availableOrbs = osloOrbs.availableOrbs;
        if (osloOrbs.NoOrbEquipped())
        {
            availableOrbText.text = "No Orbs\nAvailable";
        }
        else
        {
            availableOrbText.text = "Available\nOrbs:";
            int len = availableOrbs.Count;
            for (int i = 0; i < len; i++)
            {
                string orbName = availableOrbs[i].name;
                availableOrbImages[i].enabled = true;
                availableOrbImages[i].sprite = orbImageDict[orbName];
            }
        }
    }
}
