using UnityEngine;
using UnityEngine.AI;

public class BossPatrol : MonoBehaviour
{
    public Transform waypointParent;

    private Graph graph;
    private GraphNode currentNode;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        graph = new Graph();

        GraphNode A = graph.AddNode(waypointParent.GetChild(0));
        GraphNode B = graph.AddNode(waypointParent.GetChild(1));
        GraphNode C = graph.AddNode(waypointParent.GetChild(2));
        GraphNode D = graph.AddNode(waypointParent.GetChild(3));

        graph.AddEdge(A, B);
        graph.AddEdge(A, C);

        graph.AddEdge(B, D);
        graph.AddEdge(C, D);

        graph.startNode = A;
        currentNode = graph.startNode;

        agent.SetDestination(currentNode.waypoint.position);
    }

    private void Update()
    {
        if (currentNode == null)
        {
            return;
        }
        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (currentNode.neighbours.Count ==0)
        {
            currentNode = graph.startNode;
            agent.SetDestination(currentNode.waypoint.position);

            return;
        }

        int randomIndex = Random.Range(0, currentNode.neighbours.Count);

        currentNode = currentNode.neighbours[randomIndex];

        agent.SetDestination(currentNode.waypoint.position);
    }
}
