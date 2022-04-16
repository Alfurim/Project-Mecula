using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemy);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("hit " + enemy.name);
            if (enemy.tag == "Grunt")
            {
                enemy.GetComponent<Grunt>().TakeDamage(1);
            }
            else if (enemy.tag == "Defender")
            {
                enemy.GetComponent<Defender>().TakeDamage(1);
            }
            else
            {
                return;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
