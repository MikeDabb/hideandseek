using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject thirdPersonCamera;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        thirdPersonCamera = GetComponent<GameObject>();
    }

    void Update()
    {
        //MoveCameraWithMouse();
    }

    private void MoveCameraWithMouse()
    {
        pitch -= speedV * Input.GetAxis("Mouse Y");
        yaw += speedH * Input.GetAxis("Mouse X");


        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
