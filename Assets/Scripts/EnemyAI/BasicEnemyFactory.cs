using UnityEngine;

public class BasicEnemyFactory : EnemyFactory
{
    private GameObject patrolPrefab;
    private GameObject stationaryPrefab;

    public BasicEnemyFactory(GameObject patrol, GameObject stationary)
    {
        patrolPrefab = patrol;
        stationaryPrefab = stationary;
    }

    public override EnemyAi CreateEnemy(Vector3 position)
    {
        if (Random.value > 0.5f)
        {
            GameObject obj = GameObject.Instantiate(patrolPrefab, position, Quaternion.identity);
            return obj.GetComponent<PatrolEnemy>();
        }
        else
        {
            GameObject obj = GameObject.Instantiate(stationaryPrefab, position, Quaternion.identity);
            return obj.GetComponent<StationaryAi>();
        }
    }
}
