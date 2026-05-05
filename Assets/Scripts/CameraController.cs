using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 200f;
    public float smoothTime = 0.1f;

    public float distance = 5f;
    public float height = 2f;

    private Vector2 lookInput;
    private float yaw;
    private float pitch;

    private Vector3 currentVelocity;

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        yaw += lookInput.x * mouseSensitivity * Time.deltaTime;
        pitch -= lookInput.y * mouseSensitivity * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 targetPosition = target.position
            - rotation * Vector3.forward * distance
            + Vector3.up * height;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

        transform.LookAt(target);
    }
}    
