using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OsloLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float startingHealth;
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
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("player took damage");
    //         collision.gameObject.GetComponent<OsloLife>().TakeDamage(damage);
    //     }
    // }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // oslo takes a hit, loses HP
            Hit();
        } 
        else 
        {
            // oslo dies
            Die();
        }
    }

    private void Hit()
    {
        Debug.Log("Oslo takes a hit, current health remaining: " + currentHealth);
        // rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("hit"); // hit animation
    }

    private void Die()
    {
        Debug.Log("Oslo dies");
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death"); // death animation
        transform.GetComponent<OsloOrbs>().DestroyOrb();
        // Destroy(transform.gameObject);
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Game Over Screen");
    }
}
