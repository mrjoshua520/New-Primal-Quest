using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteThisScript : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 100f;
    public float gravity = -300f;

    public float rotateSpeed;

    Vector3 move = Vector3.zero;

    CharacterController controller;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        //gets mouse x position and rotates the target putting them in update will overwrite the variable every frame
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        transform.Rotate(0, horizontal, 0);
    }

    private void Move()
    {

        if (controller.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move);
            move *= speed;

        }
        move.y -= gravity * Time.deltaTime;
        controller.Move(move * Time.deltaTime);
        //check if there is any input and if you are not jumping
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            controller.Move(move * Time.deltaTime);
        }
    }
}