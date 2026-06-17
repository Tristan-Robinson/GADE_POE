using UnityEngine;
using System.Collections.Generic;

public class GraphNode
{
    public Transform waypoint;

    public List<GraphNode> neighbours = new List<GraphNode>();

    public GraphNode(Transform point)
    {
        waypoint = point;
    }

    public void AddNeighbour(GraphNode neighbour)
    {
        if(!neighbours.Contains(neighbour))
        {
            neighbours.Add(neighbour);
        }
    }
}
