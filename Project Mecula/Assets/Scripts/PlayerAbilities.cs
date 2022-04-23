using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Transform eye;
    public LayerMask enemyLayer;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BleedAbility();
        }
    }

    void BleedAbility()
    {
        if (Physics.Raycast(eye.position, eye.forward, out hit, Mathf.Infinity, enemyLayer))
        {
            if (hit.collider.CompareTag("Defender"))
            {
                Debug.Log("defender hit");
            }
        }
    }

}
