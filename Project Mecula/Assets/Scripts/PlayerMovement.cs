using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    float horizontalMovement;
    float verticalMovement;
    float movementMultiplier = 10f;
    float rbDrag = 6f;

    

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {

    }

    

    void ControlDrag()
    {
        rb.drag = rbDrag;
    }

    private void FixedUpdate()
    {
        MyInput();
    }

    private void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(horizontalMovement, 0f, verticalMovement);
        rb.velocity = moveDirection * Time.deltaTime * moveSpeed;
    }
    /*private void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        
    }*/
}
