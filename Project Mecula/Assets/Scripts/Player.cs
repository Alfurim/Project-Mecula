using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health = 100.0f;
    float damage = 5f;
    Vector3 respawnPos;

    void Start()
    {
        respawnPos = transform.position;
    }

    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Death Screen");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //remove later
        if (hit.gameObject.tag == "Enemy")
        {
            health -= damage;
            Debug.Log("I have hit the enemy");
            Debug.Log(health);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0.0f)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.SetPositionAndRotation(respawnPos, Quaternion.identity);
        health = 100.0f;
    }
}



















