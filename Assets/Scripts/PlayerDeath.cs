using UnityEngine;

[RequireComponent (typeof(Collider))]
public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager.instance.PlayerDeath();
        }
    }
}
