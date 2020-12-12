using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shakeable : MonoBehaviour
{
    [SerializeField]
    private float rotationDelta;
    [SerializeField]
    private float positionDelta;
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.initialRotation = Quaternion.Inverse(gameObject.transform.parent.rotation) * gameObject.transform.rotation;
        this.initialPosition = gameObject.transform.position - gameObject.transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.SetPositionAndRotation(gameObject.transform.parent.position + initialPosition + new Vector3(Random.Range(-positionDelta, positionDelta), Random.Range(-positionDelta, positionDelta), Random.Range(-positionDelta, positionDelta)), gameObject.transform.parent.rotation * initialRotation * new Quaternion(Random.Range(-rotationDelta, rotationDelta), Random.Range(-rotationDelta, rotationDelta), Random.Range(-rotationDelta, rotationDelta), 1).normalized);
    }
}
