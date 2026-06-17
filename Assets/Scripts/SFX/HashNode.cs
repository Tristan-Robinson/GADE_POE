using UnityEngine;

public class HashNode
{
    public string key;
    public AudioClip value;
    public HashNode next;

    public HashNode(string key, AudioClip value)
    {
        this.key = key;
        this.value = value;
        next = null;
    }
}
