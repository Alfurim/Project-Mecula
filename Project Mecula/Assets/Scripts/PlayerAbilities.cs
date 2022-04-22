using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Transform eye;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        if (Physics.Raycast(eye.position, eye.forward, out hit, Mathf.Infinity, 6))
        {
            if (hit.collider.CompareTag("Defender"))
            {
                Debug.Log("defender hit");
            }
            Debug.Log("hit");
        } else { Debug.Log("not hit"); }
    }

}
