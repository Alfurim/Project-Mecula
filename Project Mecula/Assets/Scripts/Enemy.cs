using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float health;
    public static float bloodGain;
    

    void Start()
    {
        if (gameObject.tag == "Grunt")
        {
            health = 2f;
            bloodGain = 10f;
        }
        if (gameObject.tag == "Defender")
        {
            health = 3f;
            bloodGain = 20f;
        }
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
            Destroy(gameObject);
            BloodMeter.StopBloodMeter(bloodGain);
        }
    }
}


