using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectLife : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public int startingHealth;
    public int currentHealth;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    // public virtual void Awake()
    // {
    //     currentHealth = startingHealth;
    // } 

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // Entity takes a hit, loses HP
            Hit();
        } 
        else 
        {
            // Entity dies
            Die();
        }
    }

    public void AddHealth(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, startingHealth);
    }

    public abstract void Hit();

    public abstract void Die();
}