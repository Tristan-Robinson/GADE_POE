using UnityEngine;

public class Node<T>
{
    public T data;          //waypoint
    public Node<T> next;    //next node

    public Node(T Value)
    {
        data = Value;
        next = null;
    }
}
