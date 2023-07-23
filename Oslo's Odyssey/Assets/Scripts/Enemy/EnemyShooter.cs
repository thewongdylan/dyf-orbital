using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform shotPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float shotInterval = 2f;
    [SerializeField] private float dir = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootProjectile", 1f, shotInterval);
        
    }

    private void ShootProjectile()
    {
        Instantiate(projectile, shotPoint.position, Quaternion.identity);
    }
}
