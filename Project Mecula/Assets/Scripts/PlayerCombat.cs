using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public Transform eye;
    public LayerMask enemyLayer;
    RaycastHit hit;
    private bool rangedAttackReady = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (rangedAttackReady == true)
            {
                RangedAttack();
                rangedAttackReady = false;
                Invoke("RangedAttackReady", 3);
            } else { Debug.Log("on cd"); }
        }
    }

    void RangedAttack()
    {
        if (Physics.Raycast(eye.position, eye.forward, out hit, Mathf.Infinity, enemyLayer))
        {
            hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }

    /*void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemy);

        Collider hitEnemy 

        
        foreach(Collider enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<Enemy>().TakeDamage(1);
            Debug.Log("enemy hit");
        }
    }*/

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }*/

    void RangedAttackReady()
    {
        rangedAttackReady = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
