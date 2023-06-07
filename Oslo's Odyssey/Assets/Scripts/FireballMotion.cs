using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMotion : ProjectileMotion
{
    [SerializeField] private LayerMask enemyLayer;

    // Start is called before the first frame update
    public override void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();  
        oslo = GameObject.Find("Oslo");
        dirMovement = oslo.transform.right;

        Invoke("DestroyProjectile", lifetime);
    }
    public override void DestroyProjectile()
    {
        Destroy(gameObject);
        oslo.GetComponent<OsloOrbs>().Spawn("Fire Orb");
    }
}
