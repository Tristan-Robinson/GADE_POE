using UnityEngine;
using System.Collections.Generic;

public class Graph
{
    public List<GraphNode> nodes = new List<GraphNode>();

    public GraphNode startNode; 

    public GraphNode AddNode(Transform point)
    {
        GraphNode node = new GraphNode(point);
        nodes.Add(node);
        return node;
    }

    public void AddEdge(GraphNode from, GraphNode to)
    {
        from.AddNeighbour(to);
    }
}
