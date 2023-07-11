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

    private void OnEnable()
    {
        currentHealth = startingHealth;
        // Debug.Log("oslo data Awake triggered");
        // Debug.Log("oslodata starting: " + startingHealth);
        // Debug.Log("oslodata current: " + currentHealth);

        availableOrbs = new List<GameObject>();
        equippedOrb = null;
        equippedOrbType = null;
        equippedOrbIndex = 0;

        // Debug.Log("created empty avail orbs list");
        // Debug.Log("avail orb list size: " + availableOrbs.Count);
    }
}
