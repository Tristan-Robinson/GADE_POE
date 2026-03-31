using UnityEngine;

public class GemPickup2 : MonoBehaviour, IPickup
{
    public int value = 10;

    public void OnPickup(PlayerMovement player)
    {
        CheckpointManager.instance.AddScore(value);
    }
}
