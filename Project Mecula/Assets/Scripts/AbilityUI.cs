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
            if (PlayerAbilities.bleedAbilityReady == true && BloodMeter.bloodMeter >= 25 && !BloodMeter.rageActive)
            {
                CombatUIText.text = "Bleed: Ready";
            }
            else if (PlayerAbilities.bleedAbilityReady == true && BloodMeter.bloodMeter < 25 && !BloodMeter.rageActive)
            {
                CombatUIText.text = "Bleed: Not Enough Blood";
            }
            else if (BloodMeter.rageActive)
            {
                CombatUIText.text = "Bleed: RAGE!!!";
            }
            else { CombatUIText.text = "Bleed: On CD"; }
        }
        else if (gameObject.CompareTag("Ranged Attack UI"))
        {
            if (PlayerCombat.rangedAttackReady == true)
            {
                CombatUIText.text = "Ranged Attack: Ready";
            }
            else { CombatUIText.text = "Ranged Attack: On CD"; }
        }
        else if (gameObject.CompareTag("Blood Infusion UI"))
        {
            if (PlayerAbilities.bloodInfusionAbilityReady == true && BloodMeter.bloodMeter >= 5 && PlayerHealth.currentHealth >= 11 && !BloodMeter.rageActive)
            {
                CombatUIText.text = "Blood Infusion: Ready";
            }
            else if (PlayerAbilities.bleedAbilityReady == true && BloodMeter.bloodMeter < 5 && PlayerHealth.currentHealth >= 11 && !BloodMeter.rageActive)
            {
                CombatUIText.text = "Blood Infusion: Not Enough Blood";
            }
            else if (PlayerAbilities.bleedAbilityReady == true && BloodMeter.bloodMeter >= 5 && PlayerHealth.currentHealth < 11 && !BloodMeter.rageActive)
            {
                CombatUIText.text = "Blood Infusion: Not Enough Health";
            }
            else if (PlayerAbilities.bleedAbilityReady == true && BloodMeter.bloodMeter < 5 && PlayerHealth.currentHealth < 11 && !BloodMeter.rageActive)
            {
                CombatUIText.text = "Blood Infusion: Not Enough Resources";
            }
            else if (BloodMeter.rageActive)
            {
                CombatUIText.text = "Blood Infusion: RAGE!!!";
            }
            else { CombatUIText.text = "Blood Infusion: Not Ready"; }
        }
        else if (gameObject.CompareTag("Blood Infusion Status UI"))
        {
            if (PlayerAbilities.bloodInfusionAbilityActive == true && !BloodMeter.rageActive)
            {
                CombatUIText.text = "Blood Infusion Status: Active";
            }
            else if (BloodMeter.rageActive)
            {
                CombatUIText.text = "Blood Infusion Status: RAGE!!!";
            }
            else { CombatUIText.text = "Blood Infusion Status: Not Active"; }
        }
    }
}
