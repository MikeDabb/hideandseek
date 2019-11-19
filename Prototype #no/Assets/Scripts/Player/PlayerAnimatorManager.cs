using System.Collections;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    //#region Monobehaviour Callbacks

    //private Animator animator;
    //// Use this for initialization
    //void Start()
    //{
    //    animator = GetComponent<Animator>();
    //    if (!animator)
    //    {
    //        Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
    //    }


    //    // Update is called once per frame
    //    void Update()
    //    {
    //        if (!animator)
    //        {
    //            return;
    //        }
    //        float h = Input.GetAxis("Horizontal");
    //        float v = Input.GetAxis("Vertical");
    //        //if (v < 0)
    //        //{
    //        //    v = 0;
    //        //}
    //        animator.SetFloat("Speed", h * h + v * v);
    //    }

    //    #endregion
    //}

    private CharacterController characterController;
    private Animator animator;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        // move direction directly from axes
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        animator.SetFloat("Speed", speed);


        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
