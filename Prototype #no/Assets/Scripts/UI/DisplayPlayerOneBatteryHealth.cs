using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerOneBatteryHealth : MonoBehaviour
{
    public Text BatteryHealthText;
    // Start is called before the first frame update
    void Start()
    {
        string batteryHealthValue = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>().batteryHealthValue.ToString();
        BatteryHealthText.text = batteryHealthValue;
    }

    // Update is called once per frame
    void Update()
    {
        string batteryHealthValue = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>().batteryHealthValue.ToString();
        BatteryHealthText.text = string.Format("Battery left: {0} %", batteryHealthValue);
    }
}
