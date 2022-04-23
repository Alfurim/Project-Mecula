using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float defenderMaxHealth;
    public static float gruntMaxHealth;
    public float currentHealth;
    public static float bloodGain;
    

    void Start()
    {
        if (gameObject.CompareTag("Grunt"))
        {
            gruntMaxHealth = 2f;
            currentHealth = gruntMaxHealth;
            bloodGain = 10f;
        }
        if (gameObject.CompareTag("Defender"))
        {
            defenderMaxHealth = 3f;
            currentHealth = defenderMaxHealth;
            bloodGain = 20f;
        }
    }

    void Update()
    {
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
            BloodMeter.StopBloodMeter(bloodGain);
        }
    }
}


