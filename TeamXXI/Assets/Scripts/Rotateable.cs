using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateable : MonoBehaviour
{
    [SerializeField]
    private float angle;
    [SerializeField]
    private Vector3 axis;
    [SerializeField]
    private bool self_propelled;
    [SerializeField]
    private GameObject connectedObj;
    [SerializeField]
    private bool hasConObj;
    [SerializeField]
    private bool hasMax;

    [SerializeField]
    private float maxRotation = 0;
    [SerializeField]
    private float minRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (self_propelled)
        {
            this.gameObject.transform.RotateAround(gameObject.transform.position, gameObject.transform.rotation * axis, Time.deltaTime * angle);
        }
        else
        {
            this.gameObject.transform.rotation = gameObject.transform.parent.rotation * Quaternion.AngleAxis(angle, axis);
        }

        if(hasConObj == true)
        {
            connectionRotation();
        }
        if (hasMax == true)
        {
            if (angle > maxRotation)
            {
                angle = maxRotation;
            }
            if (angle < minRotation)
            {
                angle = minRotation;
            }
        }
    }

    public float getAngle()
    {
        return angle;
    }

    public void setAngle(float angle)
    {
        this.angle = angle;
    }

    private void connectionRotation()
    {
        connectedObj.GetComponent<Rotateable>().setAngle(angle/16);
    }
    //-310 runter 500 hoch
}
