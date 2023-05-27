using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

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

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Trap"))
    //     {
    //         Debug.Log("enemy took damage");
    //         TakeDamage(1);
    //     }
    // }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // enemy takes a hit, loses HP
            LoseHP();
        } 
        else 
        {
            // enemy dies
            Die();
        }
    }

    private void LoseHP()
    {
        Debug.Log("enemy loses HP");
        // rb.bodyType = RigidbodyType2D.Static;
        // anim.SetTrigger("death");
        //anim.SetInteger("state", 1); // lose HP animation
        // anim.SetInteger("state", 0); // back to idle animation
    }

    private void Die()
    {
        Debug.Log("enemy dies");
        // rb.bodyType = RigidbodyType2D.Static;
        // anim.SetTrigger("death");
    }
}
