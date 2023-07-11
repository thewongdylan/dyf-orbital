using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AvailableOrbDisplay : MonoBehaviour
{
    [SerializeField] private OsloData osloData;
    [SerializeField] private GameObject oslo;
    private OsloOrbs osloOrbs;
    private List<GameObject> availableOrbs;
    [SerializeField] private TextMeshProUGUI availableOrbText;
    [SerializeField] private Image[] availableOrbImages;
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
        availableOrbs = osloData.availableOrbs;
        // Debug.Log("availDisplay Start: " + availableOrbs.Count);

        foreach (Image img in availableOrbImages) // disable all images first
        {
            img.enabled = false;
        }

        if (osloOrbs.NoOrbEquipped())
        {
            // availableOrbText.text = "No Orbs\nAvailable";
            Debug.Log("No Orbs Available");
        }
        else
        {
            availableOrbText.text = "Available\nOrbs:";
            int len = availableOrbs.Count;
            for (int i = 0; i < len; i++) // enable images based on number of available orbs
            {
                string orbName = availableOrbs[i].name;
                availableOrbImages[i].enabled = true;
                availableOrbImages[i].sprite = orbImageDict[orbName];
            }
            // Debug.Log(availableOrbs.Count + " orbs available");
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
