using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unisave.Serialization;

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
    public int equippedOrbIndex;
    public string startingEquippedOrbType;
    public List<string> startingAvailableOrbs;
    private LevitationAbility levitationAbility; // Reference to the LevitationAbility script
    [SerializeField] private GameObject abilityBar;
    private Dictionary<string, int> levelPlayedDict;
    // private bool isAbilityActive = false;

    private void Awake()
    {
        availableOrbs = osloData.availableOrbs;
        equippedOrb = osloData.equippedOrb;
        equippedOrbType = osloData.equippedOrbType;
        equippedOrbIndex = osloData.equippedOrbIndex;
        startingEquippedOrbType = osloData.startingEquippedOrbType;
        int levelPlayedTimes = osloData.levelPlayedDict[SceneManager.GetActiveScene().name];
        Debug.Log(SceneManager.GetActiveScene().name + " played "+ levelPlayedTimes + " times");
        if (levelPlayedTimes == 0) {
            Debug.Log("first time playing level");
            if (availableOrbs.Count != 0)
            {
                Debug.Log("available orbs count not 0");
                osloData.startingAvailableOrbs = availableOrbs.Select(orb => orb.name).ToList();
            }
            else
            {
                Debug.Log("available orbs count is 0");
                osloData.startingAvailableOrbs = new List<string>();
            }
            osloData.startingEquippedOrbType = equippedOrbType;
            Debug.Log("starting equipped orb: "+ startingEquippedOrbType);
        }
        else 
        {
            Debug.Log("not first time playing level");
            DestroyEquippedOrb();
            equippedOrb = null;
            availableOrbs = new List<GameObject>();
            if (osloData.startingAvailableOrbs.Count != 0)
            {
                // Debug.Log("startingAvailableOrbs not null, recreating orbs: " + Serializer.ToJsonString(this.player.startingAvailableOrbs));
                foreach (string orbName in osloData.startingAvailableOrbs)
                {
                    SpawnNewOrb(orbName);
                }
                equippedOrbIndex = 0;
            }
            equippedOrbType = osloData.startingEquippedOrbType;
            Debug.Log("starting equipped orb: "+ startingEquippedOrbType);
            Debug.Log("equipped orb: "+ equippedOrbType);
        }
        osloData.levelPlayedDict[SceneManager.GetActiveScene().name]++;


        Debug.Log("starting available orbs: " + Serializer.ToJsonString(osloData.startingAvailableOrbs));
        
        // availableOrbs = osloData.availableOrbs;
        Debug.Log("available orbs: " + Serializer.ToJsonString(availableOrbs.Select(orb => orb.name).ToList()));

        levitationAbility = GetComponent<LevitationAbility>();
        orbDict = new Dictionary<string, GameObject>(){
            {"Air Orb", airOrb},
            {"Earth Orb", earthOrb},
            {"Fire Orb", fireOrb},
            {"Water Orb", waterOrb}
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        // if (levitationAbility != null)
        // {
        //     Debug.Log("levitation not null");
        // }
        if (!NoOrbEquipped() && startingEquippedOrbType != null) // if an orb was equipped previously, spawn it
        {
            SpawnExistingOrb(equippedOrbType);
        }
        abilityBar.SetActive(false);
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
        if (equippedOrbType == "Air Orb")
        {
            abilityBar.SetActive(true);
        }
        else
        {
            abilityBar.SetActive(false);
        }
        if (AllOrbsPresent())
        {
            Debug.Log("present!");
            SceneManager.LoadScene("Ending Cutscene");
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
            SpawnOrb(orbName, incomingOrb);
            Debug.Log("equipped: " + equippedOrbType);
        }
        // does not contain incoming orb
        if (!availableOrbs.Contains(incomingOrb))
        {
            availableOrbs.Add(incomingOrb);
        }
        
        Debug.Log(orbName + " added to avail orbs list");
    }

    public void SpawnExistingOrb(string orbName)
    {
        GameObject spawnedOrb = orbDict[orbName];
        Debug.Log("spawning orb: " + spawnedOrb.ToString());
        SpawnOrb(orbName, spawnedOrb);
        Debug.Log("spawned: " + equippedOrbType);
    }

    private void SpawnOrb(string orbName, GameObject orbToSpawn)
    {
        equippedOrb = Instantiate(orbToSpawn, orbPos.position, Quaternion.identity);
        equippedOrb.GetComponent<BoxCollider2D>().enabled = false;
        equippedOrb.gameObject.transform.SetParent(transform);
        equippedOrbType = orbName;
    }

    private void ActivateAbility()
    {
        if (equippedOrbType == "Fire Orb")
        {
            Instantiate(fireball, shotPoint.position, Quaternion.identity);
            // equippedOrbType = null;
            DestroyEquippedOrb();
        }
        else if (equippedOrbType == "Water Orb")
        {
            Debug.Log("Nothing should happen, water ability is passive");
        }
        else if (equippedOrbType == "Earth Orb")
        {
            Debug.Log("Nothing should happen, earth orb not implemented yet");
        }
        else if (equippedOrbType == "Air Orb")
        { 
            if (WaterTile.inWater)
            {
                Debug.Log("levitation cannot be used underwater");
            }
            else
            {
                levitationAbility.ToggleLevitation();
                Debug.Log("levitaton activated");
            }
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

    public bool AllOrbsPresent()
    {
        return availableOrbs.Contains(airOrb) &&
               availableOrbs.Contains(earthOrb) &&
               availableOrbs.Contains(fireOrb) &&
               availableOrbs.Contains(waterOrb);
    }
}
