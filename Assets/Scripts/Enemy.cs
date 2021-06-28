using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Down!");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage Taken");
    }
}
