using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float health;
    public static float bloodGain;
    

    void Start()
    {
        if (gameObject.CompareTag("Grunt"))
        {
            health = 2f;
            bloodGain = 10f;
        }
        if (gameObject.CompareTag("Defender"))
        {
            health = 3f;
            bloodGain = 20f;
        }
    }

    void Update()
    {
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


