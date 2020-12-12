using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    [SerializeField]
    private GameObject cylinder_center, cylinder_direction, center, wheel;

    private bool hasWheel;

    [SerializeField]
    private float max, speed, progress;

    private Vector3 bar_offset;
    private int direction = 1;
    private float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        bar_offset = cylinder_center.transform.position - gameObject.transform.position;
        hasWheel = wheel != null;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion inv = Quaternion.Inverse(gameObject.transform.parent.rotation);
        /*if (Vector3.Distance(gameObject.transform.position, end) >= max && Vector3.Distance(gameObject.transform.position, start) >= max)
        {
            direction = Vector3.Distance(gameObject.transform.position, end) > Vector3.Distance(gameObject.transform.position, start) ? 1 : -1;
        } else if (Vector3.Distance(gameObject.transform.position, end) >= max)
        {
            direction = 1;
        } else if(Vector3.Distance(gameObject.transform.position, start) >= max)
        {
            direction = -1;
        }*/
        progress += Time.deltaTime * direction * speed;
        angle += Time.deltaTime * 180 * speed / max;
        if (progress < 0)
        {
            progress = 0;
            angle = 0;
            direction = 1;
        } else if(progress > max)
        {
            progress = max;
            direction = -1;
        }


        gameObject.transform.position = center.transform.position + progress * (gameObject.transform.parent.rotation * Vector3.down).normalized;
        //(direction * Time.deltaTime * speed * (world_end - world_start).normalized, Space.World);
        //cylinder_center.transform.position = gameObject.transform.position + gameObject.transform.parent.rotation * bar_offset;
        if(wheel)
        {
            wheel.transform.rotation = Quaternion.AngleAxis(angle, Vector3.left);
        }
        cylinder_center.transform.rotation = Quaternion.LookRotation(cylinder_center.transform.position - cylinder_direction.transform.position, center.transform.position - cylinder_center.transform.position);

    }
}
