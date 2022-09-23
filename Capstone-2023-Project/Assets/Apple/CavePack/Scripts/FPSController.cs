using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

    Vector2 rotation = new Vector2(0, 0);
    public float rotationSpeed = 3;
    public float movementSpeed= 3;

    bool active;
    void Start()
    {
        active = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) active = !active;
        if (active)
        {
            Cursor.lockState = CursorLockMode.Locked;

            rotation.y += Input.GetAxis("Mouse X");
            rotation.x += -Input.GetAxis("Mouse Y");
            transform.eulerAngles = (Vector2)rotation * rotationSpeed;

            transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            transform.position += transform.right * movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
