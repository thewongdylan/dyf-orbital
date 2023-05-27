using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    [SerializeField] private float speed;
    // [SerializeField] private float lifeTime;
    [SerializeField] private float distance;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Orb orb;

    // public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, enemyLayer);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Enemy")) {
                hitInfo.collider.GetComponent<EnemyLife>().TakeDamage(damage);
            }
            DestroyProjectile();
            orb.Spawn();
        }


        transform.Translate(Vector2.right * speed * Time.deltaTime); 
    }

    private void DestroyProjectile()
    {
        Debug.Log("projectile hit enemy");
        Destroy(gameObject);
    }
}
