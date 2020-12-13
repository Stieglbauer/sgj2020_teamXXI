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
    }

    void OnDrawGizmosSelected()
    {
        Vector3 overPosition = new Vector3(9, transform.position.y, 10);
        Gizmos.DrawLine(transform.position, overPosition);
        Gizmos.DrawWireSphere(overPosition, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(-Vector3.right * speed * Time.deltaTime, Space.Self);

        if (transform.position.x > 300 || transform.position.x < -300 ||
            transform.position.y > 300 || transform.position.y < -300 ||
            transform.position.z > 300 || transform.position.z < -300)
        {
            Destroy(this);
        }
    }



}
