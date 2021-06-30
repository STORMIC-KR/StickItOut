using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    //[SerializeField]
    //GameObject enemyBullet;

    //float fireRate;
    //float nextFire;

    //void Start()
    //{
    //    fireRate = 1f;
    //    nextFire = Time.time;
    //}

    private void Update()
    {
    //    CheckIfTimeToFire();

        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Down!");
            ScoreScript.score++;
        }
    }

    //void CheckIfTimeToFire()
    //{
    //    if(Time.time > nextFire)
    //    {
    //        Instantiate(enemyBullet, transform.position, Quaternion.identity);
    //        nextFire = Time.time + fireRate;
    //    }
    //}

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage Taken");
    }
}
