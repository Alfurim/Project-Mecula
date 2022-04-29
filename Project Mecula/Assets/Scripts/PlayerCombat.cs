using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform eye;
    public LayerMask enemyLayer;
    RaycastHit hit;
    public static bool rangedAttackReady;
    public int rangedAttackCD;

    private void Start()
    {
        rangedAttackReady = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !BloodMeter.rageActive)
        {
            if (rangedAttackReady == true && !PlayerAbilities.bloodInfusionAbilityActive)
            {
                RangedAttack(1);
                rangedAttackReady = false;
                Invoke(nameof(RangedAttackReady), rangedAttackCD);
            }
            else if (rangedAttackReady == true && PlayerAbilities.bloodInfusionAbilityActive)
            {
                RangedAttack(2);
                rangedAttackReady = false;
                PlayerAbilities.bloodInfusionAbilityReady = true;
                PlayerAbilities.bloodInfusionAbilityActive = false;
                Invoke(nameof(RangedAttackReady), rangedAttackCD);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (rangedAttackReady == true)
            {
                RangedAttack(2);
                rangedAttackReady = false;
                Invoke(nameof(RangedAttackReady), rangedAttackCD / 2);
            }
        }
    }

    void RangedAttack(int damage)
    {
        if (Physics.Raycast(eye.position, eye.forward, out hit, Mathf.Infinity, enemyLayer))
        {
            hit.collider.gameObject.GetComponent<EnemyAI>().TakeDamage(damage);
        }
    }

    void RangedAttackReady()
    {
        rangedAttackReady = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 direction = eye.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }
}
