using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : ObjectLife
{
    public void Awake()
    {
        currentHealth = startingHealth;
    }
    public override void Hit()
    {
        Debug.Log("Enemy takes a hit, current health remaining: " + currentHealth);
        anim.SetTrigger("hit"); // hit animation
    }

    public override void Die()
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
