using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform eye;
    public LayerMask enemyLayer;
    RaycastHit hit;
    public static bool rangedAttackReady;
    public int rangedAttackCD = 5;

    private void Start()
    {
        rangedAttackReady = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
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
            else { Debug.Log("on cd"); }
        }
    }

    void RangedAttack(int damage)
    {
        if (Physics.Raycast(eye.position, eye.forward, out hit, Mathf.Infinity, enemyLayer))
        {
            hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    void RangedAttackReady()
    {
        rangedAttackReady = true;
    }
}
