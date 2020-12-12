using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankSound : MonoBehaviour
{
    public List<AudioClip> his = new List<AudioClip>();
    public List<AudioClip> los = new List<AudioClip>();
    public AudioSource source;
    public HingeJoint reference;
    public Rotateable rotateableReference;
    private bool nextHi = false;
    private float lastAngle = 0.0f;
    private float deltaAngle = 0.0f;

    public float getAngle()
    {
        if (reference != null) {
            return reference.angle;
        }
        if (rotateableReference != null) {
            return rotateableReference.getAngle();
        }
        return 0.0f;
    }

    public void Squeak() {
        var sources = nextHi ? his : los;
        source.clip = sources[Random.Range(0, sources.Count)];
        source.time = 0;
        source.Play();
        nextHi = !nextHi;
        deltaAngle = 0.0f;
    }

    void Update()
    {
        float angle = getAngle();
        deltaAngle += Mathf.DeltaAngle(lastAngle, angle);
        if (Mathf.Abs(deltaAngle) > 180.0f) {
            Squeak();
        }
        lastAngle = angle;
    }
}
