using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSpeed : MonoBehaviour
{
    public List<Cylinder> cylinders = new List<Cylinder>();
    public List<AudioSource> sources = new List<AudioSource>();
    [Range(0, 2)]
    public float speed = 1.0f;

    void Update()
    {
        foreach (Cylinder c in cylinders) {
            c.setSpeed(speed);
        }
        foreach (AudioSource s in sources) {
            s.pitch = speed;
        }
    }
}
