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
            else { Invoke("BleedAbilityReady", bleedAbilityCD); }
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
