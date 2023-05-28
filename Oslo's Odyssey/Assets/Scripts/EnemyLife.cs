using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float startingHealth;
    public float currentHealth { get; private set; }
    [SerializeField] private float damage;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    } 

    private void Awake()
    {
        currentHealth = startingHealth;
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<OsloLife>().TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // enemy takes a hit, loses HP
            Hit();
        } 
        else 
        {
            // enemy dies
            Die();
        }
    }

    private void Hit()
    {
        Debug.Log("Enemy takes a hit, current health remaining: " + currentHealth);
        anim.SetTrigger("hit"); // hit animation
    }

    private void Die()
    {
        Debug.Log("Enemy dies");
        transform.GetComponent<WaypointFollower>().SetMotion(false); // Only works if the enemy also has a WaypointFollower script attached
        anim.SetTrigger("death"); // death animation
    }

    private void DestroyEnemy()
    {
        Destroy(transform.gameObject);
    }
}
