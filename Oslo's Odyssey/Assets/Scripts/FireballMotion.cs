using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMotion : ProjectileMotion
{
    // Start is called before the first frame update
    public override void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        oslo = GameObject.Find("Oslo");
        dirMovement = oslo.transform.right;

        Invoke("DestroyProjectile", lifetime);
    }
    public override void DestroyProjectile()
    {
        Destroy(gameObject);
        oslo.GetComponent<OsloOrbs>().SpawnExistingOrb("Fire Orb");
    }
}
