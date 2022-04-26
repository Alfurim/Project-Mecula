using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float currentHealth;
    private float decreasePerSecond;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100f;
        decreasePerSecond = 1f * Time.deltaTime;
    }

    private void Update()
    {
        healthText.text = "Health: " + (int)currentHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);

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
