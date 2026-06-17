using UnityEngine;

public class GemPickup : MonoBehaviour, IPickup
{
    public int value = 1;

    public void OnPickup(PlayerMovement player)
    {
        CheckpointManager.instance.AddScore(value);

        SFXManager.Instance.PlaySound("GemCollect");
    }
}
