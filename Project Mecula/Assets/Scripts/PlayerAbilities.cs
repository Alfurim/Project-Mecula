using System;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Transform eye;
    public LayerMask enemyLayer;
    RaycastHit hit;
    public static bool bleedAbilityReady;
    public static bool bloodInfusionAbilityReady;
    public static bool bloodInfusionAbilityActive;
    public int bleedAbilityCD = 10;

    void Start()
    {
        bleedAbilityReady = true;
        bloodInfusionAbilityReady = true;
        bloodInfusionAbilityActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (bleedAbilityReady)
            {
                BleedAbility();
                BloodMeter.bloodMeter -= 25;
                Invoke(nameof(BleedAbilityReady), bleedAbilityCD);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerHealth.currentHealth >= 11)
        {
            if (bloodInfusionAbilityReady && !bloodInfusionAbilityActive)
            {
                PlayerHealth.currentHealth -= 10f;
                BloodMeter.bloodMeter -= 5;
                bloodInfusionAbilityReady = false;
                bloodInfusionAbilityActive = true;
            }
            else if (bloodInfusionAbilityReady && bloodInfusionAbilityActive)
            {
                return;
            }
            else if (!bloodInfusionAbilityReady) return;
        }
    }

    void BleedAbility()
    {
        if (Physics.Raycast(eye.position, eye.forward, out hit, Mathf.Infinity, enemyLayer))
        {
            hit.collider.gameObject.GetComponent<DefenderAI>().TakeDamage(1);
            Invoke(nameof(BleedDamageTick), 2);
            Debug.Log("hit, bleed started");
        }
        bleedAbilityReady = false;
    }

    void BleedDamageTick()
    {
        hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(1);
    }

    void BleedAbilityReady()
    {
        bleedAbilityReady = true;
    }
}
