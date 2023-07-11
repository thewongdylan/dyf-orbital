using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OsloLife : ObjectLife
{
    [SerializeField] private OsloData osloData;

    public override void Start()
    {
        base.Start();
        startingHealth = osloData.startingHealth;
        currentHealth = osloData.currentHealth;
    }

    private void Update()
    {
        osloData.currentHealth = currentHealth;
    }

    public override void Hit()
    {
        Debug.Log("Oslo takes a hit, current health remaining: " + currentHealth);
        anim.SetTrigger("hit"); // hit animation
    }
    public override void Die()
    {
        Debug.Log("Oslo dies");
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death"); // death animation
        transform.GetComponent<OsloOrbs>().DestroyEquippedOrb();
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
