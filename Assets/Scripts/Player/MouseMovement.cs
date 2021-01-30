using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerTransform;

    // Rotation around x
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Hide And Lock cursor to centre of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse position
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Up and down movement -  in 180range
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Set up rotation around x ( up and down)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Rotate player on X axis with mouse
        playerTransform.Rotate(Vector3.up * mouseX); 
    }
}
