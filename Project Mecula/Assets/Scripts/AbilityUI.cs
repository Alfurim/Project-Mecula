using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public Text CombatUIText;

    void Update()
    {
        if (gameObject.CompareTag("Ranged Attack UI"))
        {
            if (PlayerAbilities.bleedAbilityReady == true)
            {
                CombatUIText.text = "Bleed: Ready";
            }
            else { CombatUIText.text = "Bleed: On CD"; }
        }

        else if (gameObject.CompareTag("Bleed Ability UI"))
        {
            if (PlayerCombat.rangedAttackReady == true)
            {
                CombatUIText.text = "Ranged Attack: Ready";
            }
            else { CombatUIText.text = "Ranged Attack: Not Ready"; }
        } 
    }
}
