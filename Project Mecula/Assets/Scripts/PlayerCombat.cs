using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform eye;
    public LayerMask enemyLayer;
    RaycastHit hit;
    private bool rangedAttackReady = true;
    public int rangedAttackCD = 3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (rangedAttackReady == true)
            {
                RangedAttack();
                rangedAttackReady = false;
                Invoke("RangedAttackReady", rangedAttackCD);
            }
            else { Debug.Log("on cd"); }
        }
    }

    void RangedAttack()
    {
        if (Physics.Raycast(eye.position, eye.forward, out hit, Mathf.Infinity, enemyLayer))
        {
            hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }

    void RangedAttackReady()
    {
        rangedAttackReady = true;
    }
}
