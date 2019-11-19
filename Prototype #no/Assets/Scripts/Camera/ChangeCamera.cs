using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera minimapCamera;

    public GameObject ceiling;
    public GameObject lightForCamera;

    public void ShowThirdPersonView()
    {
        thirdPersonCamera.enabled = true;
            
        minimapCamera.enabled = false;
    }

    public void ShowMinimapView()
    {
        thirdPersonCamera.enabled = false;
        minimapCamera.enabled = true;
    }

    void Start()
    {
        GameObject ceiling = GetComponent<GameObject>();
        GameObject lightForCamera = GetComponent<GameObject>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            ShowMinimapView();
            ceiling.SetActive(false);
            lightForCamera.SetActive(true);
        }
        else
        {
            ShowThirdPersonView();
            ceiling.SetActive(true);
            lightForCamera.SetActive(false);
        }

    }
}
