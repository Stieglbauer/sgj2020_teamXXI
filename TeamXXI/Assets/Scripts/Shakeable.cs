using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shakeable : MonoBehaviour
{
    [SerializeField]
    private float rotationDelta;
    [SerializeField]
    private GameObject reference;
    [SerializeField]
    private float positionDelta;
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.initialRotation = gameObject.transform.localRotation;
        this.initialPosition = gameObject.transform.position - gameObject.transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(reference)
        {
            this.transform.SetPositionAndRotation(reference.transform.position + new Vector3(Random.Range(-positionDelta, positionDelta), Random.Range(-positionDelta, positionDelta), Random.Range(-positionDelta, positionDelta)), reference.transform.rotation * new Quaternion(Random.Range(-rotationDelta, rotationDelta), Random.Range(-rotationDelta, rotationDelta), Random.Range(-rotationDelta, rotationDelta), 1).normalized);
        } else
        {
            Debug.LogError("please add a ref " + gameObject.name);
        }
        //this.transform.position = (gameObject.transform.parent.position + initialPosition + new Vector3(Random.Range(-positionDelta, positionDelta), Random.Range(-positionDelta, positionDelta), Random.Range(-positionDelta, positionDelta)));
        //this.transform.localRotation = initialRotation * new Quaternion(Random.Range(-rotationDelta, rotationDelta), Random.Range(-rotationDelta, rotationDelta), Random.Range(-rotationDelta, rotationDelta), 1).normalized;
    }
}
