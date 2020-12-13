using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerScript : MonoBehaviour
{
    public AudioClip towerRepaired;
    public AudioClip towerCorrupted;
    public AudioClip cannonDeflected;
    public AudioClip oneIncoming;
    public AudioClip twoIncoming;
    public AudioClip threeIncoming;
    public AudioClip waveClear;
    public AudioClip missionComplete;

    public AudioSource source;
    public List<AudioClip> queue = new List<AudioClip>();

    public static SpeakerScript GetSpeaker()
    {
        return GameObject.FindObjectOfType<SpeakerScript>();
    }

    public void Queue(AudioClip clip)
    {
        queue.Add(clip);
    }

    void Update()
    {
        if (queue.Count > 0 && !source.isPlaying) {
            source.clip = queue[0];
            queue.RemoveAt(0);
            source.time = 0;
            source.Play();
        }
    }
}
