using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    private CharacterController controller;

    public float speed = 5f;
    public float jumpHeight = 4f;
    public float gravity = -18f;
    private float verticalVelocity;

    public float rotationSpeed = 10f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) 
    { 
        if (context.performed && controller.isGrounded)
        {
           verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void Update()
    {
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;
        Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y);
        Vector3 velocity = move * speed + Vector3.up * verticalVelocity;

        controller.Move(velocity * Time.deltaTime);

        if (move != Vector3.zero)
        {
            Quaternion targetRotaion = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotaion, rotationSpeed * Time.deltaTime);
        }
    }
}