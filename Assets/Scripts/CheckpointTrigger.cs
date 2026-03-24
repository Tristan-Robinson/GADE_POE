using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager.instance.ReachCheckpoint(transform.position);
        }
    }
}
