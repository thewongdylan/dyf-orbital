using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform shotPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float shotInterval = 2f;
    private Rigidbody2D rb;
    public string shotDir = "left";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootProjectile", 1f, shotInterval);
        if (shotDir == "left")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (shotDir == "right")
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void ShootProjectile()
    {
        ProjectileMotion.
        Instantiate(projectile, shotPoint.position, Quaternion.identity);
    }
}
