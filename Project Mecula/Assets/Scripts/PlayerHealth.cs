using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float maxHealth;
    private float currentHealth;
    private float decreasePerSecond;
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
<<<<<<< HEAD
=======
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
>>>>>>> parent of bf2c3cf (aaa)

        if (currentHealth < 1)
        {
            SceneManager.LoadScene("SampleScene");
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
