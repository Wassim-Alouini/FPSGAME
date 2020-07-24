using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] float moveSensitivity = 100f;
    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * moveSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * moveSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerRb.rotation = Quaternion.Euler(playerRb.rotation.eulerAngles + Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
