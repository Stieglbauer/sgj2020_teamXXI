using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 100f;

    public Transform playerBody;

    Ray ray;
    RaycastHit hit;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity *Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetKey(KeyCode.Mouse0))
        {
            float currAng = hit.transform.GetComponent<Rotateable>().getAngle();
            hit.transform.GetComponent<Rotateable>().setAngle(currAng + 0.25f);
        }
        else if (Physics.Raycast(ray, out hit) && Input.GetKey(KeyCode.Mouse1))
        {
            float currAng = hit.transform.GetComponent<Rotateable>().getAngle();
            hit.transform.GetComponent<Rotateable>().setAngle(currAng - 0.25f);
        }
    }
}
