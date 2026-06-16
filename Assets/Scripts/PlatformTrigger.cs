using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public MovingPlatform platform;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated)
            return;

        if (other.CompareTag("player"))
        {
            platform.ActivatePlatform();
            activated = true; 
        }
    }
}
