using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsloOrbs : MonoBehaviour
{
    [SerializeField] private OsloData osloData;
    [SerializeField] private Transform orbPos;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform abilityBarPos;
    public GameObject airOrb;
    public GameObject earthOrb;
    public GameObject fireOrb;
    public GameObject waterOrb;
    [SerializeField] private GameObject fireball;
    private Dictionary<string, GameObject> orbDict;
    public List<GameObject> availableOrbs;
    public GameObject equippedOrb;
    public string equippedOrbType;
    private int equippedOrbIndex;
    private LevitationAbility levitationAbility; // Reference to the LevitationAbility script
    [SerializeField] private GameObject abilityBar;
    // private bool isAbilityActive = false;

    private void Awake()
    {
        // Debug.Log("osloOrbs Awake");
        availableOrbs = osloData.availableOrbs;
        equippedOrb = osloData.equippedOrb;
        equippedOrbType = osloData.equippedOrbType;
        equippedOrbIndex = osloData.equippedOrbIndex;
        // Debug.Log("osloData.equippedOrb:" + osloData.equippedOrb + osloData.equippedOrbType);

        // Debug.Log("osloOrbs obtained orb data from osloData"); 
        // Debug.Log("Awake: " + availableOrbs.Count + " " + equippedOrbType); 
        // Debug.Log("Awake: orb equipped? :" + (equippedOrb != null));
    }

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("osloOrbs Start");
        levitationAbility = GetComponent<LevitationAbility>();
        orbDict = new Dictionary<string, GameObject>(){
            {"Air Orb", airOrb},
            {"Earth Orb", earthOrb},
            {"Fire Orb", fireOrb},
            {"Water Orb", waterOrb}
        };
        // Debug.Log("Start: " + availableOrbs.Count + " " + equippedOrbType); 


        if (!NoOrbEquipped()) // if an orb was equipped previously, spawn it
        {
            // Debug.Log("trying to spawn: " + equippedOrbType);
            SpawnExistingOrb(equippedOrbType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        osloData.availableOrbs = availableOrbs;
        osloData.equippedOrb = equippedOrb;
        osloData.equippedOrbType = equippedOrbType;
        osloData.equippedOrbIndex = equippedOrbIndex;

        if (Input.GetButtonDown("Ability")) //spacebar
        {
             ActivateAbility();   
        }
        if (Input.GetButtonDown("Switch")) //e key
        {
             SwitchOrb();   
        }
    }

    public bool NoOrbEquipped()
    {
        return equippedOrbType == null;
    }

    public void SpawnNewOrb(string orbName)
    {
        GameObject incomingOrb = orbDict[orbName];
        Debug.Log("incoming orb: " + orbName);

        if (NoOrbEquipped())
        {
            equippedOrb = Instantiate(incomingOrb, orbPos.position, Quaternion.identity);
            equippedOrb.GetComponent<BoxCollider2D>().enabled = false;
            equippedOrb.gameObject.transform.SetParent(transform);
            equippedOrbType = orbName;
            Debug.Log("equipped: " + equippedOrbType);
        }
        availableOrbs.Add(incomingOrb);
        Debug.Log(orbName + " added to avail orbs list");

        if (orbName == "Air Orb")
        {
            GameObject spawnedAbilityBar = Instantiate(abilityBar, abilityBarPos.position, Quaternion.identity);
            spawnedAbilityBar.gameObject.transform.SetParent(transform);
            spawnedAbilityBar.GetComponent<Canvas>().worldCamera = Camera.main;
            Debug.Log("generated ability bar for air orb");
        }
    }

    public void SpawnExistingOrb(string orbName)
    {
        GameObject spawnedOrb = orbDict[orbName];
        Debug.Log("spawning orb: " + spawnedOrb.ToString());
        equippedOrb = Instantiate(spawnedOrb, orbPos.position, Quaternion.identity);
        equippedOrb.GetComponent<BoxCollider2D>().enabled = false;
        equippedOrb.gameObject.transform.SetParent(transform);
        equippedOrbType = orbName;
        Debug.Log("spawned: " + equippedOrbType);

        if (orbName == "Air Orb")
        {
            GameObject spawnedAbilityBar = Instantiate(abilityBar, abilityBarPos.position, Quaternion.identity);
            spawnedAbilityBar.gameObject.transform.SetParent(transform);
            spawnedAbilityBar.GetComponent<Canvas>().worldCamera = Camera.main;
            Debug.Log("generated ability bar for air orb");
        }
    }

    private void ActivateAbility()
    {
        if (equippedOrbType == "Fire Orb")
        {
            Instantiate(fireball, shotPoint.position, Quaternion.identity);
            equippedOrbType = null;
            DestroyEquippedOrb();
        }
        else if (equippedOrbType == "Water Orb")
        {
            // Instantiate(waterOrb, shotPoint.position, Quaternion.identity);
            // equippedOrbType = null;
            // DestroyEquippedOrb();
        }
        else if (equippedOrbType == "Earth Orb")
        {
            // Instantiate(earthOrb, shotPoint.position, Quaternion.identity);
            // equippedOrbType = null;
            // DestroyEquippedOrb();
        }
        else if (equippedOrbType == "Air Orb")
        { 
            levitationAbility.ToggleLevitation();
            Debug.Log("triggered inside airorb condition");
            
        }
    }

    private void SwitchOrb()
    {
        DestroyEquippedOrb();
        if (equippedOrbIndex < (availableOrbs.Count - 1))
        {
            equippedOrbIndex++;
        }
        else
        {
            equippedOrbIndex = 0;
        }
        equippedOrb = availableOrbs[equippedOrbIndex];
        equippedOrbType = equippedOrb.name;
        SpawnExistingOrb(equippedOrbType);
        Debug.Log("switched to: " + equippedOrb);
    }

    public void DestroyEquippedOrb()
    {
        Destroy(equippedOrb);
    }
}
