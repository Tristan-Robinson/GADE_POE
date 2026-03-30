using UnityEngine;

public class CheckpointStack
{
    private CheckpointData[] stackArray;
    private int top;
    private int maxSize;

    public CheckpointStack(int size)
    {
        maxSize = size;
        stackArray = new CheckpointData[maxSize];
        top = -1;
    }

    public void Push(CheckpointData item)
    {
        if (IsFull())
        {
            Debug.Log("Stack is full");
            return;
        }

        top++;
        stackArray[top] = item;
    }

    public CheckpointData Pop() 
    {
        if (IsEmpty())
        {
            Debug.Log("Stack is empty");
            return null;
        }
        
        CheckpointData item = stackArray[top];
        stackArray[top] = null;
        top--;
        return item;
    }

    public CheckpointData Peek()
    {
        if (IsEmpty())
        {
            Debug.Log("Stack is empty");
            return null;
        }
        return stackArray[top];
    }

    public bool IsEmpty() 
    { return top == -1; }

    public bool IsFull() 
    { return top == maxSize - 1; }
}
