using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Transform eye;
    public LayerMask enemyLayer;
    RaycastHit hit;
    public static bool bleedAbilityReady = true;
    public int bleedAbilityCD = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (bleedAbilityReady)
            {
                BleedAbility();
                Invoke(nameof(BleedAbilityReady), bleedAbilityCD);
            }
        }
    }

    void BleedAbility()
    {
        if (Physics.Raycast(eye.position, eye.forward, out hit, Mathf.Infinity, enemyLayer))
        {
            hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(1);
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
