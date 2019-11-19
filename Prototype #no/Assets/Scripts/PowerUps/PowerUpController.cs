using UnityEngine;

public class PowerUpController : MonoBehaviour
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
            Destroy(transform.gameObject);
        }
    }
}
