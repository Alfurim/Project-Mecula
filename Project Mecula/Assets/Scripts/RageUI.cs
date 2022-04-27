using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageUI : MonoBehaviour
{
    public Text rageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BloodMeter.rageActive)
        {
            rageText.text = "Rage: Active";
        }
        else { rageText.text = "Rage: Inactive"; }

    }
}
