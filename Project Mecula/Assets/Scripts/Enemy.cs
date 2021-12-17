using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50;
    int score = 0;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("i have hit the player");
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            //if health is lower or equal to 0 the enemy will die
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        score++;
        Debug.Log(score);
    }
}