using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 dirMovement;
    public float speed = 10f;
    public int damage;
    public float lifetime = 2f;
    public GameObject oslo;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        oslo = GameObject.Find("Oslo");
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
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyLife>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
    }

    public virtual void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
