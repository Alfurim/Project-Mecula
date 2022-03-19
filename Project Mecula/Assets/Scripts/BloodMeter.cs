using System;
using UnityEngine;
using UnityEngine.UI;

public class BloodMeter : MonoBehaviour
{
    public float bloodMeter;
    public float bloodMeterDecreasePerSecond;
    public Text bloodMeterText;
    void Start()
    {
        bloodMeter = 50f;
        bloodMeterDecreasePerSecond = 0.5f * (Time.deltaTime * 2);
    }

    void Update()
    {
        bloodMeterText.text = "Blood Meter: " + (int)bloodMeter;
        if (bloodMeter > 0)
        {
            bloodMeter -= bloodMeterDecreasePerSecond;
        }
    }
}
