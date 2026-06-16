using System.Net;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;
    public bool loop = true;

    private int currentIndex = 0;
    private Vector3 target;
    private Vector3 lastPosition;
    private Vector3 frameMovement;

    private bool isActive = false;

    private void Start()
    {
        if (points.Length == 0) return;
        
            currentIndex = 0;
            target = points[currentIndex].position;
        
        
        lastPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (!isActive || points.Length == 0)
        {
            frameMovement = Vector3.zero;
            lastPosition = transform.position;
            return; 
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) <0.1f)
        {
            currentIndex++;

            if (currentIndex >= points.Length)
            {
                currentIndex = loop ? 0 : points.Length -1 ;
            }

            target = points[currentIndex].position;
        }

        frameMovement = transform.position - lastPosition;
        lastPosition = transform.position;
    }

    public Vector3 GetMovement()
    {
        return frameMovement;
    }

    public void ActivatePlatform()
    {
        isActive = true;
    }
    public void DeactivatePlatfrom()
    {
        isActive = false;
    }
}
