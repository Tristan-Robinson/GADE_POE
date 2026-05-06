using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject patrolPrefab;
    public GameObject stationaryPrefab;

    private EnemyFactory factory;

    private void Start()
    {
        factory = new BasicEnemyFactory(patrolPrefab, stationaryPrefab);

        SpawnEnemies();
    }
    void SpawnEnemies ()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos = transform.position + new Vector3(i * 2, 0 , 0);

            EnemyAi enemy = factory.CreateEnemy(pos);
            enemy.Initialize();
        }
    }
}
