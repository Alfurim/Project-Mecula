using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50;
    int score = 0;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            //if health is lower or equal to 0 then player will die
            Die();
        }
    }


    void Die()
    {
        Destroy(gameObject);
        score++;
        Debug.Log(score);

    }



    void EnemyDead()
    {
        Destroy(gameObject);
        //when enemy is dead the game object will be deleted
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        Debug.Log("I am alive");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("i have hit the player");
    }

}

