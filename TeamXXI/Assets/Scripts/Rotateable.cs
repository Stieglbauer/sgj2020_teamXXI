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
    }

    public float getAngle()
    {
        return angle;
    }

    public void setAngle(float angle)
    {
        this.angle = angle;
    }
}
