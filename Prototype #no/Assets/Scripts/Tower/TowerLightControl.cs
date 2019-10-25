using UnityEngine;

public class TowerLightControl : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Camera thirdPersonCamera;
    public Camera firstPersonFlashLightCamera;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            thirdPersonCamera.enabled = false;
            firstPersonFlashLightCamera.enabled = true;
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

        else
        {
            thirdPersonCamera.enabled = true;
            firstPersonFlashLightCamera.enabled = false;
        }
        

        
    }
}
