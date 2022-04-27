using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Transform eye;
    public LayerMask enemyLayer;
    RaycastHit hit;
    private bool bleedAbilityReady = true;
    public int bleedAbilityCD = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (bleedAbilityReady)
            {
                BleedAbility();
            }
<<<<<<< HEAD
            else { Invoke("BleedAbilityReady", bleedAbilityCD); }
=======
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerHealth.currentHealth >= 11)
        {
            Debug.Log("hello");
            //Debug.Log("hello");
            if (bloodInfusionAbilityReady && !bloodInfusionAbilityActive)
            {
                PlayerHealth.currentHealth -= 10f;
                bloodInfusionAbilityReady = false;
                bloodInfusionAbilityActive = true;
            }
            else if (bloodInfusionAbilityReady && bloodInfusionAbilityActive)
            {
                return;
            }
            else if (!bloodInfusionAbilityReady) return;
>>>>>>> parent of bf2c3cf (aaa)
        }
    }

    void BleedAbility()
    {
        if (Physics.Raycast(eye.position, eye.forward, out hit, Mathf.Infinity, enemyLayer))
        {
            hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(1);
            Invoke("BleedDamageTick", 2);
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
