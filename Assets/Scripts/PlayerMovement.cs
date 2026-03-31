using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    private bool isSprinting;
    private CharacterController controller;

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

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        jumpsRemaining = maxJumps;
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
    {   //resets jumps
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
            jumpsRemaining = maxJumps;
        }
        //gravity
        verticalVelocity += gravity * Time.deltaTime;

        //movement speed
        float currentSpeed = (isSprinting ? sprintSpeed : walkSpeed) * speedMultiplier;

        //movement
        Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y);
        Vector3 velocity = move * currentSpeed + Vector3.up * verticalVelocity;
        controller.Move(velocity * Time.deltaTime);

        if (move != Vector3.zero)
        {
            Quaternion targetRotaion = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotaion, rotationSpeed * Time.deltaTime);
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