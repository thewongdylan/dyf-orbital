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

    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float dirX;
    private int state;

    // public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        // if (rb.velocity.x > 0f)
        // {
        //     Debug.Log("flight animation");
        //     anim.SetTrigger("inFlight");
        //     sprite.flipX = false;
        // }
        // else if (rb.velocity.x < 0f)
        // {
        //     Debug.Log("flight animation");
        //     anim.SetTrigger("inFlight");
        //     sprite.flipX = true;
        // }


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
