using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsloOrbs : MonoBehaviour
{
    [SerializeField] private Transform orbPos;
    [SerializeField] private Transform shotPoint;
    public GameObject airOrb;
    public GameObject earthOrb;
    public GameObject fireOrb;
    public GameObject waterOrb;
    [SerializeField] private GameObject fireball;
    private Dictionary<string, GameObject> orbDict;
    private List<GameObject> availableOrbs;
    public GameObject equippedOrb = null;
    public string equippedOrbType = null;
    private LevitationAbility levitationAbility; // Reference to the LevitationAbility script
    // private bool isAbilityActive = false;

    // Start is called before the first frame update
    void Start()
    {
        levitationAbility = GetComponent<LevitationAbility>();
        orbDict = new Dictionary<string, GameObject>(){
            {"Air Orb", airOrb},
            {"Earth Orb", earthOrb},
            {"Fire Orb", fireOrb},
            {"Water Orb", waterOrb}
        };
        availableOrbs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ability"))
        {
             ActivateAbility();   
        }
        if (Input.GetButtonDown("Switch"))
        {
             SwitchOrb();   
        }
    }

    public bool NoOrbEquipped()
    {
        return equippedOrb == null;
    }

    public void Spawn(string orbName)
    {
        GameObject incomingOrb = orbDict[orbName];
        Debug.Log("incoming orb: " + incomingOrb.ToString());

        if (NoOrbEquipped())
        {
            equippedOrb = Instantiate(incomingOrb, orbPos.position, Quaternion.identity);
            equippedOrb.gameObject.transform.SetParent(transform);
            equippedOrbType = orbName.Split()[0]; // first word of orbName (type)
            Debug.Log("picked up: " + equippedOrbType);
        }
        availableOrbs.Add(incomingOrb);
        Debug.Log("orb added to avail orbs list");
        Debug.Log("available orbs: " + availableOrbs);
    }

    private void ActivateAbility()
    {
        if (equippedOrbType == "Fire")
        {
            Instantiate(fireball, shotPoint.position, Quaternion.identity);
            equippedOrbType = null;
            DestroyOrb();
        }
        else if (equippedOrbType == "Water")
        {
            Instantiate(waterOrb, shotPoint.position, Quaternion.identity);
            equippedOrbType = null;
            DestroyOrb();
        }
        else if (equippedOrbType == "Earth")
        {
            Instantiate(earthOrb, shotPoint.position, Quaternion.identity);
            equippedOrbType = null;
            DestroyOrb();
        }
        else if (equippedOrbType == "Air" && equippedOrb != null)
        {
            if (levitationAbility != null)
            {
                levitationAbility.ToggleLevitation();
                Debug.Log("triggered inside airorb condition");
            }
        }
    }

    private void SwitchOrb()
    {

    }

    public void DestroyOrb()
    {
        Destroy(equippedOrb);
    }
}
