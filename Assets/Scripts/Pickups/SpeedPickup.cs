using UnityEngine;

public class SpeedPickup : MonoBehaviour, IPickup
{
    public float multiplier = 1.5f;
    public float duration = 5f;

    public void OnPickup(PlayerMovement player)
    {
        player.IncreaseSpeed(multiplier, duration);
    }
}
