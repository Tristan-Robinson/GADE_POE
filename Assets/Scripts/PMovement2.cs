using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PMovement2 : MonoBehaviour
{
    private Vector2 moveDirection;
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpHeight = 7f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    private bool isGrounded;

    public float rotationSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y);
        Vector3 velocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);

        rb.linearVelocity = velocity;

        if (move != Vector3.zero)
        {
            Quaternion targetRotaion = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotaion, rotationSpeed * Time.deltaTime);
        }
    }
}
