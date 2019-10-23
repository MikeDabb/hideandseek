using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;
    public float movementSpeed;
    public float rotationSpeed = 200.0f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Transform transform = GetComponent<Transform>();
        Animator anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        MovePlayerOnInput();
    }

    private void MovePlayerOnInput()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Debug.Log(moveVertical);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        transform.Rotate(0, moveHorizontal * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, moveVertical * Time.deltaTime * movementSpeed);

        if (moveVertical > 0)
        {
            anim.SetBool("IsRunning", true);
        }

        if (moveVertical < 0.2 && moveVertical > 0)
        {
            anim.SetBool("IsRunning", false);
        }

        if ( moveVertical > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("IsSprinting", true);
            movementSpeed = 40f;
        }

        if (moveVertical > 0 && Input.GetKey(KeyCode.RightShift))
        {
            anim.SetBool("IsSprinting", true);
            movementSpeed = 40f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("IsSprinting", false);
        }

        if (moveVertical < 0)
        {
            anim.SetBool("IsRunningBackwards", true);
            movementSpeed = 10f;
        }

        else if(moveVertical == 0)
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsSprinting", false);
            anim.SetBool("IsRunningBackwards", false);
            movementSpeed = 15f;
        }
    }
}
