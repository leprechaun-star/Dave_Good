using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camscript : MonoBehaviour
{

    public float sensitivity = 1000f;
    public float xRotation = 100f;


    public Transform playerBody;
    public Quaternion localRotate;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        localRotate = transform.localRotation;
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
