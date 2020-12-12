using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    [SerializeField]
    private GameObject cylinder_center, cylinder_direction;

    [SerializeField]
    private float max, speed, progress;

    private Vector3 start, end, bar_offset;
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        bar_offset = cylinder_center.transform.position - gameObject.transform.position;
        start = gameObject.transform.position;
        end = gameObject.transform.position + Vector3.down * max;
        gameObject.transform.Translate(progress * (end - start), Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, end) >= max && Vector3.Distance(gameObject.transform.position, end) >= max)
        {
            direction = Vector3.Distance(gameObject.transform.position, end) > Vector3.Distance(gameObject.transform.position, start) ? 1 : -1;
        } else if (Vector3.Distance(gameObject.transform.position, end) >= max)
        {
            direction = 1;
        } else if(Vector3.Distance(gameObject.transform.position, start) >= max)
        {
            direction = -1;
        }
        gameObject.transform.Translate(direction * Time.deltaTime * speed * (end - start).normalized, Space.World);
        cylinder_center.transform.position = gameObject.transform.position + bar_offset;
        cylinder_center.transform.rotation = Quaternion.LookRotation(cylinder_center.transform.position - cylinder_direction.transform.position, Vector3.up);

    }
}
