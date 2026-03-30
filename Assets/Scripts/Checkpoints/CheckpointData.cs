using UnityEngine;

[System.Serializable]
public class CheckpointData
{
    public Vector3 position;
    public int lives;
    public int score;

    public CheckpointData(Vector3 position, int lives, int score)
    {
        this.position = position;
        this.lives = lives;
        this.score = score;
    }
}
