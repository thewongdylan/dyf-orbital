using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTile : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float damageInterval = 1f;
    private float timer;
    private bool isPlayerTakingDamage;
    [SerializeField] OsloLife osloLife;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OnCollisionEnter2D: collided with player");
            // osloLife = collision.gameObject.GetComponent<OsloLife>();
            isPlayerTakingDamage = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OnCollisionExit2D: player left");
            // collision.gameObject.GetComponent<OsloLife>().TakeDamage(damage);
            isPlayerTakingDamage = false;
        }
    }

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        if (isPlayerTakingDamage && timer >= damageInterval)
        {
            osloLife.TakeDamage(damage);
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

}
