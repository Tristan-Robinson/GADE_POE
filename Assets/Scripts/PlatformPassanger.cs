using UnityEngine;

public class PlatformPassanger : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal.y > 0.5)
        {
            if (hit.collider.GetComponent<MovingPlatform>())
            {
                transform.parent = hit.collider.transform;
            }
        }
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (!Physics.Raycast(ray, 1.5f))
        {
            transform.parent = null;
        }
    }
}
