using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Oslo Data")]
public class OsloData : ScriptableObject
{
    public int startingHealth;
    public int currentHealth;
    public List<GameObject> availableOrbs; 
    public GameObject equippedOrb;
    public string equippedOrbType;
    public int equippedOrbIndex;
    public int savedSceneIndex;
    public int deathSceneIndex;
    public string startingEquippedOrbType;
    public List<string> startingAvailableOrbs;
    public Dictionary<string, int> levelPlayedDict;


    private void OnEnable()
    {
        currentHealth = startingHealth;
        availableOrbs = new List<GameObject>();
        equippedOrb = null;
        equippedOrbType = null;
        equippedOrbIndex = 0;
        savedSceneIndex = 0;
        deathSceneIndex = 0;
        startingEquippedOrbType = null;
        startingAvailableOrbs = new List<string>();
        levelPlayedDict = new Dictionary<string, int>(){
            {"Title", 0},
            {"Login", 0},
            {"Continue", 0},
            {"Cutscene", 0},
            {"TutorialSelect", 0},
            {"Tutorial", 0},
            {"Air", 0},
            {"Fire", 0},
            {"Water", 0},
            {"Earth", 0},
            {"EndingCutscene", 0},
            {"End", 0},
            {"GameOver", 0},
        };
    }
}
