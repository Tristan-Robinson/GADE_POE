using JetBrains.Annotations;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioSource audioSource;

    private HashMap soundMap;

    [Header("Audio Clips")]
    public AudioClip checkpoint;
    public AudioClip platform;
    public AudioClip gemCollect;
    public AudioClip death;
    public AudioClip victory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        soundMap = new HashMap(20); 

        soundMap.Add("Checkpoint", checkpoint);
        soundMap.Add("Platform", platform);
        soundMap.Add("GemCollect", gemCollect);
        soundMap.Add("Death", death);
        soundMap.Add("Victory", victory);
    }

    public void PlaySound(string soundName)
    {
        AudioClip clip = soundMap.Get(soundName);

        if(clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Sound not found: " + soundName);  
        }
    }
}
