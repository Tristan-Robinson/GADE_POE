using UnityEngine;
using TMPro;

public class CheckpointManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public static CheckpointManager instance;

    public Transform player;

    public int currentLives;
    public int maxLives = 3;

    public int currentScore;

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
        currentLives = maxLives;

        CheckpointData startCheckpoint = new CheckpointData(player.position, currentLives, currentScore);

        checkpointStack.Push(startCheckpoint);

        mainCheckpoint = new CheckpointData(player.position, maxLives, currentScore);

        UpdateScoreUI();
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
        mainCheckpoint = new CheckpointData(checkpointPosition, maxLives, currentScore);
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
            currentScore = currentCheckpoint.score;

            TeleportPlayer(currentCheckpoint.position);
            Debug.Log("Respawnded at Checkpoint");

            UpdateScoreUI();
        }
    }

    private void RespawnAtMainCheckpoint()
    {
        if (mainCheckpoint != null)
        {
            TeleportPlayer(mainCheckpoint.position);

            currentScore = mainCheckpoint.score;
            currentLives = maxLives;

            UpdateScoreUI();

            Debug.Log("Player died. Respawned at Main checkpoint");
        }
    }

    private void TeleportPlayer(Vector3 position)
    {
        CharacterController controller = player.GetComponent<CharacterController>();

        if (controller != null)
        {
            controller.enabled = false;
            player.position = position;
            controller.enabled = true;
        }
        else
        {
            player.position = position;
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }
}
