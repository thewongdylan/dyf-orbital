using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{

    private Vector3 orbPosCoords;
    [SerializeField] private float orbOffsetX;
    [SerializeField] private float orbOffsetY;    
    [SerializeField] private GameObject fireOrb;
    [SerializeField] private Transform shotPoint;


    // Start is called before the first frame update
    private void Start()
    {
        // orbPos = GameObject.Find("orbPos");
        orbPosCoords = new Vector3(transform.position.x + orbOffsetX, transform.position.y + orbOffsetY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Fire();       
        }
    }

    public void Spawn()
    {
        GameObject spawnedOrb = Instantiate(fireOrb, orbPosCoords, transform.rotation);
        spawnedOrb.gameObject.transform.SetParent(transform); 
    }

    private void Fire()
    {
        Instantiate(fireOrb, shotPoint.position, transform.rotation);
    }


    
}
