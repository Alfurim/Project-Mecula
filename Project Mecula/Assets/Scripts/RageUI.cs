using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageUI : MonoBehaviour
{
    public Text rageText;

    void Update()
    {
        if (BloodMeter.rageActive)
        {
            rageText.text = "Rage: Active";
        }
        else { rageText.text = "Rage: Inactive"; }
    }
}
