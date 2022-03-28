using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float decreasePerSecond;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        decreasePerSecond = 1f * Time.deltaTime;
    }

    private void Update()
    {
        healthText.text = "Health: " + (int)currentHealth;

        if (currentHealth <= 0)
        {
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (BloodMeter.bloodMeter <= 0)
        {
            currentHealth -= decreasePerSecond;
        }
    }
}
