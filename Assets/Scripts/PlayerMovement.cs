using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    private bool isSprinting;
    private CharacterController controller;
    private MovingPlatform currentPlatform;

    private PlayerState currentState;
    private Animator animator;

    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float speedMultiplier = 1f;

    public float jumpHeight = 4f;
    public float gravity = -18f;
    private float verticalVelocity;
    private int maxJumps = 1;
    private int jumpsRemaining;

    public float rotationSpeed = 10f;

    public int gems = 0;

    private Transform cam;

    public enum PlayerState
    {
        Idle,
        Walking,
        Running,
        Jumping
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        controller = GetComponent<CharacterController>();
        jumpsRemaining = maxJumps;
        cam = Camera.main.transform;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) 
    { 
        if (context.performed && jumpsRemaining > 0)
        {
           verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpsRemaining--;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.performed;
    }

    void Update()
    {   
        //resets jumps
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
            jumpsRemaining = maxJumps;
            currentPlatform = null;
        }

        //gravity
        verticalVelocity += gravity * Time.deltaTime;

        //camera direction
        Vector3 cameraForward = cam.forward;
        Vector3 cameraRight = cam.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 move = cameraForward * moveDirection.y + cameraRight * moveDirection.x;

        //movement speed
        float currentSpeed = (isSprinting ? sprintSpeed : walkSpeed) * speedMultiplier;

        Vector3 horizontalMove = move * currentSpeed;

        //movement
        Vector3 velocity = horizontalMove + Vector3.up * verticalVelocity;

        Vector3 platformMovement = Vector3.zero;

        if (controller.isGrounded && currentPlatform != null)
        {
            platformMovement = currentPlatform.GetDeltaMovement();
        }

        controller.Move((velocity + platformMovement) * Time.deltaTime);

        //rotation
        if (move != Vector3.zero)
        {

            Quaternion targetrotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetrotation, rotationSpeed * Time.deltaTime);

        }

        UpdateState();
        UpdateAnimation();

    }

    void UpdateState()
    {
        if(!controller.isGrounded)
        {
            currentState = PlayerState.Jumping;
            return;
        }
        
        if (moveDirection.magnitude <0.1f)
        {
            currentState = PlayerState.Idle;
        }
        else if (isSprinting)
        {
            currentState = PlayerState.Running;
        }
        else
        {
            currentState = PlayerState.Walking;
        }
    }

    void UpdateAnimation()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                animator.SetFloat("Speed", 0);
                animator.SetBool("IsJumping", false);
                break;

            case PlayerState.Running:
                animator.SetFloat("Speed", 1);
                animator.SetBool("IsJumping", false);
                break;

            case PlayerState.Walking:
                animator.SetFloat("Speed", 5);
                animator.SetBool("IsJumping", false);
                break;

            case PlayerState.Jumping:
                animator.SetBool("IsJumping", true);
                break;
        }
    }

    //MovingPlatform
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        MovingPlatform platform = hit.collider.GetComponent<MovingPlatform>();

        if (platform != null)
        {
            currentPlatform = platform;
        }
    }


    //pickups
    public void AddGems(int amount)
    {
        gems += amount;
        Debug.Log("Gems: " + gems);
    }

    public void IncreaseSpeed(float multiplier, float duration)
    {
        StartCoroutine(SpeedBoost(multiplier, duration));
    }

    private System.Collections.IEnumerator SpeedBoost(float multiplier, float duration)
    {
        speedMultiplier *= multiplier;
        yield return new WaitForSeconds(duration);
        speedMultiplier /= multiplier;
    }

    public void EnableDoubleJump()
    {
        maxJumps = 2;
        jumpsRemaining = maxJumps;
        Debug.Log("Double jump unlocked");
    }
}