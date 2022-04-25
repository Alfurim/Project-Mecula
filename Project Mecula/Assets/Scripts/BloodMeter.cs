using UnityEngine;
using UnityEngine.UI;

public class BloodMeter : MonoBehaviour
{
    public static float bloodMeter;
    public static float decreasePerSecond;
    public static float stopTimer;
    public bool rageActive;
    public float rageTimer;
    public Text bloodMeterText;

    void Start()
    {
        bloodMeter = 50f;
        decreasePerSecond = 2f * Time.deltaTime;
        stopTimer = 2f;
        rageTimer = 5f;
    }

    void Update()
    {
        bloodMeterText.text = "Blood Meter: " + (int)bloodMeter;
        bloodMeter = Mathf.Clamp(bloodMeter, 0, 100);
        stopTimer = Mathf.Clamp(stopTimer, 0, 2);

        if (bloodMeter >= 100f && Input.GetKeyDown(KeyCode.Q))
        {
            RageActivate();
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            bloodMeter += 40f;
        }*/
    }

    private void FixedUpdate()
    {
        if (stopTimer < 2f && !rageActive)
        {
            decreasePerSecond = 0f * Time.deltaTime;
            stopTimer += 1f * Time.deltaTime;
        }
        else if (rageActive)
        {
            rageTimer += 1f * Time.deltaTime;
            decreasePerSecond = rageTimer * Time.deltaTime;
            if (bloodMeter <= 10f) rageActive = false;
        }
        else
        {
            decreasePerSecond = 2f * Time.deltaTime;
        }
        if (bloodMeter > 0)
        {
            bloodMeter -= decreasePerSecond;
        }

        
    }

    public static void StopBloodMeter(float bloodGain)
    {
        stopTimer = 0f;
        bloodMeter += bloodGain;
    }

    void RageActivate()
    {
        rageActive = true;
    }    
}
