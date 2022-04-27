using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    public Text dashText;

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.readyToDash)
        {
            dashText.text = "Dash: Ready";
        }
        else { dashText.text = "Dash: On CD"; }
    }
}
