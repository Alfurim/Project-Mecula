using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private float desiredMoveSpeed;
    private float lastDesiredMoveSpeed;
    public float wallrunSpeed;
    public float speedIncreaseMultiplier;
    public float slopeIncreaseMultiplier;
    public float groundDrag;

    [Header("Dash")]
    public float dashSpeed;
    public float dashCooldown;
    public float dashMultiplier;
    public static bool readyToDash;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode dashKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public float rageMultiplier;
    public bool key1PickedUp = false;
    public bool key2PickedUp = false;
    public bool key3PickedUp = false;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        wallrunning,
        air
    }

    public bool wallrunning;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        readyToDash = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetKey(dashKey) && readyToDash)
        {
            readyToDash = false;
            
            Dash();
            if (!BloodMeter.rageActive)
            {
                Invoke(nameof(ResetDash), dashCooldown);
            } else { Invoke(nameof(ResetDash), dashCooldown / 2); }
        }
    }

    private void StateHandler()
    {
        // Mode - Wallrunning
        if (wallrunning)
        {
            state = MovementState.wallrunning;
            desiredMoveSpeed = wallrunSpeed;
        }

        // Mode - Walking
        else if (grounded)
        {
            state = MovementState.walking;
            desiredMoveSpeed = moveSpeed;
        }

        // Mode - Air
        else
        {
            state = MovementState.air;
        }

        // check if desired move speed has changed drastically
        if (Mathf.Abs(desiredMoveSpeed - lastDesiredMoveSpeed) > 4f && moveSpeed != 0)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothlyLerpMoveSpeed());

            print("Lerp Started!");
        }
        else
        {
            moveSpeed = desiredMoveSpeed;
        }

        lastDesiredMoveSpeed = desiredMoveSpeed;
    }

    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        // smoothly lerp movementSpeed to desired value
        float time = 0;
        float difference = Mathf.Abs(desiredMoveSpeed - moveSpeed);
        float startValue = moveSpeed;

        while (time < difference)
        {
            moveSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, time / difference);

            if (OnSlope())
            {
                float slopeAngle = Vector3.Angle(Vector3.up, slopeHit.normal);
                float slopeAngleIncrease = 1 + (slopeAngle / 90f);

                time += Time.deltaTime * speedIncreaseMultiplier * slopeIncreaseMultiplier * slopeAngleIncrease;
            }
            else
                time += Time.deltaTime * speedIncreaseMultiplier;

            yield return null;
        }

        moveSpeed = desiredMoveSpeed;
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on slope
        if (OnSlope() && !exitingSlope && !BloodMeter.rageActive)
        {
            rb.AddForce(20f * moveSpeed * GetSlopeMoveDirection(moveDirection), ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }
        else if (OnSlope() && !exitingSlope && BloodMeter.rageActive)
        {
            rb.AddForce(20f * moveSpeed * rageMultiplier * GetSlopeMoveDirection(moveDirection), ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }
        // on ground
        else if (grounded && !BloodMeter.rageActive)
            rb.AddForce(10f * moveSpeed * moveDirection.normalized, ForceMode.Force);
        else if (grounded && BloodMeter.rageActive)
            rb.AddForce(10f * moveSpeed * rageMultiplier * moveDirection.normalized, ForceMode.Force);
        // in air
        else if (!grounded && !BloodMeter.rageActive)
            rb.AddForce(10f * airMultiplier * moveSpeed * moveDirection.normalized, ForceMode.Force);
        else if (!grounded && BloodMeter.rageActive)
            rb.AddForce(10f * airMultiplier * moveSpeed * rageMultiplier * moveDirection.normalized, ForceMode.Force);
        // turn gravity off while on slope
        if (!wallrunning) rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        // limiting speed on slope
        if (OnSlope() && !exitingSlope && !BloodMeter.rageActive)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }
        else if (OnSlope() && !exitingSlope && BloodMeter.rageActive)
        {
            if (rb.velocity.magnitude > moveSpeed * rageMultiplier)
                rb.velocity = moveSpeed * rageMultiplier * rb.velocity.normalized;
        }

        // limiting speed on ground or in air
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            if (!BloodMeter.rageActive)
            {
                // limit velocity if needed
                if (flatVel.magnitude > moveSpeed)
                {
                    Vector3 limitedVel = flatVel.normalized * moveSpeed;
                    rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
                }
            }
            else
            {
                // limit velocity if needed
                if (flatVel.magnitude > moveSpeed * rageMultiplier)
                {
                    Vector3 limitedVel = moveSpeed * rageMultiplier * flatVel.normalized;
                    rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
                }
            }
        }
    }

    private void Jump()
    {
        exitingSlope = true;

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
        exitingSlope = false;
    }

    void Dash()
    {
        exitingSlope = true;

        rb.AddForce( moveSpeed * dashMultiplier * moveDirection.normalized, ForceMode.VelocityChange);
    }

    void ResetDash()
    {
        readyToDash = true;
        exitingSlope = false;
    }

    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    public Vector3 GetSlopeMoveDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }

    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Health Pack"))
        {
            PlayerHealth.currentHealth += 50;
            Destroy(other.gameObject);
        }
        else if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Blood Pack"))
        {
            BloodMeter.bloodMeter += 50;
            BloodMeter.stopTimer = 0;
            Destroy(other.gameObject);
        }
        else if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Key1"))
        {
            Destroy(other.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Key1"));
        }
        else if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Key2"))
        {
            Destroy(other.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Key2"));
        }
        else if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Key3"))
        {
            Destroy(other.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Key3"));
        }
        else if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}