using UnityEngine;

public abstract class EnemyFactory
{
    public abstract EnemyAi CreateEnemy(Vector3 position);
}
