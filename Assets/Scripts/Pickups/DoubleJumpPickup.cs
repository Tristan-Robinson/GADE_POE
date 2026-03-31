using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour, IPickup
{
    public void OnPickup(PlayerMovement player)
    {
        player.EnableDoubleJump();
    }
}
