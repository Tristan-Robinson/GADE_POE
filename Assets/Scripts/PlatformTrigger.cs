using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public MovingPlatform platform;
    public NotificationUI notificationUI;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated)
            return;

        if (other.CompareTag("Player"))
        {
            platform.ActivatePlatform();

            notificationUI.ShowMessage("The Platform Started Moving!", 3f);

            activated = true;
        }
    }
}
