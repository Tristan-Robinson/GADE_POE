using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 target;
    private Vector3 lastPosition;
    private Vector3 frameMovement;
    private Vector3 SmoothedMovement;

    private void Start()
    {
        target = pointB.position;
        lastPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) <0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }

        frameMovement = transform.position - lastPosition;
        lastPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 rawmovement = transform.position - lastPosition;

        SmoothedMovement = Vector3.Lerp(SmoothedMovement, rawmovement, 0.5f);

        lastPosition = transform.position;
    }

    public Vector3 GetMovement()
    {
        return frameMovement;

        return SmoothedMovement;
    }
}
