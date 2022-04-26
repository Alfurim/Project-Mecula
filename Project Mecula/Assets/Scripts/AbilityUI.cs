using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public Text CombatUIText;

    void Update()
    {
        if (gameObject.CompareTag("Bleed Ability UI"))
        {
            if (PlayerAbilities.bleedAbilityReady == true)
            {
                CombatUIText.text = "Bleed: Ready";
            }
            else { CombatUIText.text = "Bleed: On CD"; }
        }
        else if (gameObject.CompareTag("Ranged Attack UI"))
        {
            if (PlayerCombat.rangedAttackReady == true)
            {
                CombatUIText.text = "Ranged Attack: Ready";
            }
            else { CombatUIText.text = "Ranged Attack: Not Ready"; }
        }
        else if (gameObject.CompareTag("Blood Infusion UI"))
        {
            if (PlayerAbilities.bloodInfusionAbilityReady == true)
            {
                CombatUIText.text = "Blood Infusion: Ready";
            }
            else { CombatUIText.text = "Blood Infusion: Not Ready"; }
        }
        else if (gameObject.CompareTag("Blood Infusion Status UI"))
        {
            if (PlayerAbilities.bloodInfusionAbilityActive == true)
            {
                CombatUIText.text = "Blood Infusion: Active";
            }
            else { CombatUIText.text = "Blood Infusion: Not Active"; }
        }
    }
}
