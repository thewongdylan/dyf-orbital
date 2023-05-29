using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    // [SerializeField] private float lifeTime;
    [SerializeField] private int damage;
    [SerializeField] private float lifetime = 1;
    [SerializeField] private GameObject enemy;
    private GameObject oslo;
    [SerializeField] private LayerMask playerLayer;
    private Vector3 dirMovement;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();  
        oslo = GameObject.Find("Oslo");
        // dirMovement = (enemy.transform.position - oslo.transform.position).normalized;
        // dirMovement = new Vector3(dirMovement.x, 0, 0);
        dirMovement = new Vector3(-1, 0, 0);

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
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<OsloLife>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
