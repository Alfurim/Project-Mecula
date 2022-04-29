using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float currentHealth;
    private float decreasePerSecond;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100f;
        decreasePerSecond = 1f * Time.deltaTime;
        slider.value = currentHealth;
    }

    private void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        slider.value = currentHealth;

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
