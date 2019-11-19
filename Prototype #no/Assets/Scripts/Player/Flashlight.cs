using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameObject))]
public class Flashlight : MonoBehaviour
{
    public float batteryHealthValue = 100.0f;
    const float batteryDrainSpeed = 4.2f;
    //public Text batteryHealthText;

    public GameObject spotlight;
    public GameObject colliderDetector;
    

    void Start()
    {
        //batteryHealthText.text = string.Format("Battery left: {0} %", batteryHealthValue.ToString());
    }

    void Update()
    {
        UseLightWhenBatteryIsLeft();
        DrainBatteryIfLightIsOn();
        //batteryHealthText.text = string.Format("Battery left: {0} %", batteryHealthValue.ToString());
    }

    private void ShowLightOnInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (spotlight.activeSelf)
            {
                DisableFlashlight();
                DisableColliderDetector();
            }

            else
            {
                EnableFlashlight();
                EnableColliderDetector();
            }
        }
    }

    private void UseLightWhenBatteryIsLeft()
    {
        if (batteryHealthValue > 0)
        {
            ShowLightOnInput();
        }

        else if (batteryHealthValue <= 0)
        {
            batteryHealthValue = 0;
            DisableFlashlight();
            DisableColliderDetector();
        }
    }

    // Enable / Disable Collider Detector
    private void EnableColliderDetector() => colliderDetector.SetActive(true);
    private void DisableColliderDetector() => colliderDetector.SetActive(false);

    // Enable / Disable Flashlight's spotlight
    private void EnableFlashlight() => spotlight.SetActive(true);
    private void DisableFlashlight() => spotlight.SetActive(false);

    // Drain Batter If Light is on

    private void DrainBatteryIfLightIsOn()
    {
        if (spotlight.activeSelf)
        {
            Debug.Log("Flashlight light is enabled");
            DrainBattery();
        }
    }

    private void DrainBattery()
    {
        Debug.Log("DrainBattery() was called");
        batteryHealthValue -= batteryDrainSpeed * Time.deltaTime;
    }

}
