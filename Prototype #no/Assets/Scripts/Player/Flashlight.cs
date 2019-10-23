using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject obj;

    void Start()
    {
    }

    void Update()
    {
        ShowLightOnInput();
    }

    private void ShowLightOnInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(obj.activeSelf)
                obj.SetActive(false);
            else
            {
                obj.SetActive(true);
            }
        }
    }
}
