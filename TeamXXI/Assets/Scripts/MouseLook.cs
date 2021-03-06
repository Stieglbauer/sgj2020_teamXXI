﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;
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

        float turnAngle = Input.GetKey(KeyCode.Mouse0) ? 1000 : Input.GetKey(KeyCode.Mouse1) ? -1000 : 0;
        ui.GetComponent<Text>().text = "";
        if (turnAngle != 0) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Rotateable hitRotateable = hit.transform.GetComponent<Rotateable>();
                if (hitRotateable != null) {
                    hitRotateable.setAngle(hitRotateable.getAngle() + Time.deltaTime * turnAngle);
                }
                RepairPos rp = hit.transform.GetComponent<RepairPos>();
                if(rp != null)
                {
                    ui.GetComponent<Text>().text = "Repairing...";
                    rp.repair(Time.deltaTime);
                }
            }
        } else
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                RepairPos rp = hit.transform.GetComponent<RepairPos>();
                if (rp != null)
                {
                    if (rp.isDamaged())
                        ui.GetComponent<Text>().text = "Click to repair";
                }
            }

        }
    }
}
