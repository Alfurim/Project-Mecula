using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float defenderMaxHealth;
    public static float gruntMaxHealth;
    public float currentHealth;
    public float bloodGain;


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


