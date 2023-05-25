using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            LoseLife();
        }
        else
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // player dies, loses a life
            LoseLife();
        } 
        else 
        {
            // game over
            Die();
        }
    }

    private void LoseLife()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("loseLife");
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        transform.position = new Vector3(-3.5f, 0, 0);
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetInteger("state", 0);
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Game Over Screen");
    }
}
