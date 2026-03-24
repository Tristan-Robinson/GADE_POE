using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    public Transform player;
    public int currentLives = 3;
    public int currentScore = 0;

    private CheckpointStack checkpointStack;

    //Main
    private CheckpointData mainCheckpoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        checkpointStack = new CheckpointStack(10);
    }

    private void Start()
    {
        mainCheckpoint = new CheckpointData(player.position, 3, 0);
        checkpointStack.Push(new CheckpointData(player.position, currentLives, currentScore));
    }

    public void ReachCheckpoint(Vector3 checkpointPosition)
    {
        CheckpointData newCheckpoint = new CheckpointData(checkpointPosition, currentLives, currentScore);

        if (!checkpointStack.IsEmpty())
        {
            checkpointStack.Pop();
        }

        checkpointStack.Push(newCheckpoint);
        Debug.Log("Checkpoint reached" + checkpointPosition);
    }

    public void setMainCheckpoint(Vector3 checkpointPosition)
    {
        mainCheckpoint = new CheckpointData(checkpointPosition, 3, currentScore);
        Debug.Log("Main Checkpoint set: " + checkpointPosition);
    }

    public void PlayerDeath()
    {
        currentLives--;
        Debug.Log("Player died. Lives left: " + currentLives);

        if (currentLives > 0)
        {
            RespawnAtStackCheckpoint();
        }
        else
        {
            RespawnAtMainCheckpoint();
        }
    }

    private void RespawnAtStackCheckpoint()
    {
        CheckpointData currentCheckpoint = checkpointStack.Peek();

        if (currentCheckpoint != null)
        {
            currentCheckpoint.lives = currentLives;
            currentCheckpoint.score = currentScore;

            player.position = currentCheckpoint.position;
            Debug.Log("Respawnded at Checkpoint");
        }
    }

    private void RespawnAtMainCheckpoint()
    {
        if (mainCheckpoint != null)
        {
            player.position = mainCheckpoint.position;

            currentLives = 3;
            currentScore = mainCheckpoint.score;

            Debug.Log("Player died. Respawned at Main checkpoint");
        }
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
    }
}
