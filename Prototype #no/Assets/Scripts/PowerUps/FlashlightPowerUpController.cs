using UnityEngine;

public class FlashlightPowerUpController : MonoBehaviour
{
    private Transform transform;
    private readonly float rotationSpeed = 150f;
    

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        RotateBox();
    }

    private void RotateBox()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerOne")
        {
            RestoreBatteryLight();
            Destroy(transform.gameObject);
        }
    }

    private void RestoreBatteryLight()
    {
        var flashlightBattery = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>().batteryHealthValue;
        flashlightBattery += 30.0f;
    }
}
