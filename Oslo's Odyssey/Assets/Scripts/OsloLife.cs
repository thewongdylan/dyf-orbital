using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OsloLife : ObjectLife
{
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
