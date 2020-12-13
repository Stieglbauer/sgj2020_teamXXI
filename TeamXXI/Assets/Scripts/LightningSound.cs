using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSound : MonoBehaviour
{
    public AudioSource source;
    public float startDelay;

    void Start()
    {
        source.PlayDelayed(startDelay);
    }

}
