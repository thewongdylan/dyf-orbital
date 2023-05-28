using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMotion : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    // [SerializeField] private float lifeTime;
    [SerializeField] private float distance;
    [SerializeField] private int damage;
    [SerializeField] private float lifetime = 1;
    [SerializeField] private LayerMask enemyLayer;
    private GameObject oslo;
    private Vector3 dirMovement;


    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();  
        oslo = GameObject.Find("Oslo");
        dirMovement = oslo.transform.right;

        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirMovement * speed * Time.deltaTime); 
        if (dirMovement.x > 0f)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (dirMovement.x < 0f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyLife>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
        oslo.GetComponent<OsloOrbs>().Spawn("Fire Orb");
    }
}
