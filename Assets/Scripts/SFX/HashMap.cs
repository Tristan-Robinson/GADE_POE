using UnityEngine;

public class HashMap
{
    private HashNode[] buckets;

    public HashMap(int size)
    {
        buckets = new HashNode[size];
    }

    private int Hash(string key)
    {
        int hash = 0;

        foreach (char c in key)
        {
            hash += c;
        }

        return Mathf.Abs(hash) % buckets.Length;
    }

    public void Add(string key, AudioClip value)
    {
        int index = Hash(key);

        HashNode node = buckets[index];

        if (node == null)
        {
            buckets[index] = new HashNode(key, value);
            return;
        }
        while (node.next != null)
        {
            if (node.key == key)
            {
                node.value = value;
                return;
            }

            node = node.next;
        }

        if (node.key == key)
        {
            node.value = value; 
            return;
        }

        node.next = new HashNode(key, value);
    }

    public AudioClip Get(string key)
    {
        int index = Hash(key);

        HashNode node = buckets[index];

        while (node != null)
        {
            if (node.key == key)
            {
                return node.value;
            }

            node = node.next;
        }

        return null;
    }
}
