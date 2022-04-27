using UnityEngine;
using UnityEngine.UI;

public class BloodMeter : MonoBehaviour
{
    public static float bloodMeter;
    public static float decreasePerSecond;
    public static float stopTimer;
<<<<<<< HEAD
=======
    public bool rageActive;
    public float rageTimer;
>>>>>>> parent of bf2c3cf (aaa)
    public Text bloodMeterText;

    void Start()
    {
        bloodMeter = 50f;
        decreasePerSecond = 2f * Time.deltaTime;
        stopTimer = 2f;
<<<<<<< HEAD
=======
        rageTimer = 5f;
>>>>>>> parent of bf2c3cf (aaa)
    }

    void Update()
    {
        bloodMeterText.text = "Blood Meter: " + (int)bloodMeter;
<<<<<<< HEAD
=======
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
>>>>>>> parent of bf2c3cf (aaa)
    }

    private void FixedUpdate()
    {
        if (stopTimer < 2f)
        {
            decreasePerSecond = 0f * Time.deltaTime;
            stopTimer += 1f * Time.deltaTime;
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
}
