using UnityEngine;

public class RotateLightOverTime : MonoBehaviour
{
    private Transform transform;
    public float rotationSpeed;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
        if (transform.rotation.eulerAngles.z > 90)
        {
            rotationSpeed = 3f;
        }

        else if (transform.rotation.eulerAngles.z > 240)
        {
            rotationSpeed = 2f;
        }
    }
}
