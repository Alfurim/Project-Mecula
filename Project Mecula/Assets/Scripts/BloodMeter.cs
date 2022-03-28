using System;
using UnityEngine;
using UnityEngine.UI;

public class BloodMeter : MonoBehaviour
{
    public static float bloodMeter;
    public static float decreasePerSecond;
    public static float stopTimer;
    public Text bloodMeterText;
    void Start()
    {
        bloodMeter = 50f;
        decreasePerSecond = 2f * Time.deltaTime;
        stopTimer = 2f;
    }

    void Update()
    {
        bloodMeterText.text = "Blood Meter: " + (int)bloodMeter;
    }

    private void FixedUpdate()
    {
        if (stopTimer < 2f)
        {
            decreasePerSecond = 0f * Time.deltaTime;
            stopTimer = stopTimer + 1f * Time.deltaTime;
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
        BloodMeter.bloodMeter += bloodGain;
        BloodMeter.stopTimer = 0;
    }
}
