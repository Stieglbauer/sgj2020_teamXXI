using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float currentXPosition;
    private float currentZPosition;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosition = transform.position;
        Vector3 overPosition = new Vector3(9, startPosition.y, 10);

        // TODO: Choose the rotation to fly to the next tower
        //rotation = Quaternion.FromToRotation(startPosition, overPosition);
        //Quaternion direction = Quaternion.LookRotation(overPosition - startPosition, Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, 30 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

 
}
