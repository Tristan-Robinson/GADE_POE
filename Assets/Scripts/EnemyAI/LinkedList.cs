using UnityEngine;

public class LinkedList<T>
{
    public Node<T> head;

    public void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node<T> current = head;

        while(current.next != null)
        {
            current = current.next;
        }

        current.next = newNode;
    }

    public Node<T> GetFirst()
    {
        return head;
    }
}
