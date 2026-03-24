using UnityEngine;

public class MainCheckpointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager.instance.setMainCheckpoint(transform.position);
        }
    }
}
