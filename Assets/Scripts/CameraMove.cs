using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, player.eulerAngles.y, 0f);
    }
}
