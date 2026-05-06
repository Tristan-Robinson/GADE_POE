using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAi : MonoBehaviour
{
    protected NavMeshAgent agent;

    public float speed;
    public float size;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void Initialize()
    {
        agent.speed = speed;
        transform.localScale = Vector3.one * size;
    }
}
