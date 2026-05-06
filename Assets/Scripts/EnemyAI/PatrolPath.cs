using UnityEngine;
using UnityEngine.AI;

public class PatrolPath : MonoBehaviour
{
    public Transform[] waypointLocation;

    private LinkedList<Transform> waypoints = new LinkedList<Transform>();
    private Node<Transform> currentNode;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //adding waypoints
        foreach (Transform wp  in waypointLocation)
        {
            waypoints.Add(wp);
        }

        currentNode = waypoints.GetFirst();

        if(currentNode != null)
        {
            agent.SetDestination(currentNode.data.position);
        }
    }

    private void Update()
    {
        if (currentNode == null)
        {
            return;
        }
        if (!agent.pathPending && agent.remainingDistance <0.2f)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (currentNode.next != null)
        {
            currentNode = currentNode.next;
        }
        else
        {
            //Look up first waypoint
            currentNode = waypoints.GetFirst();
        }

        agent.SetDestination(currentNode.data.position);
    }
}
