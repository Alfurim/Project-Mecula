using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunValues : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //left mouse to shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                //if target is in range
                //target can take damage
                target.TakeDamage(damage);
            }
        }
    }


}
