using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed = 4;
    private float tempMovementSpeed;
    Animator anim;
    [SerializeField] private AnimationCurve jumpFallOff;
    public float jumpMultiplier = 15;
    public KeyCode jumpKey;
    CharacterController charControl;
    Vector3 moveDirForward;
    Vector3 moveDirSide;
    private bool isJumping;

    // Use this for initialization
    void Start ()
    {
        charControl = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float h = Input.GetAxis("Horizontal") * movementSpeed;
        float v = Input.GetAxis("Vertical") * movementSpeed;
        MovePlayer(h, v);
	}

    void MovePlayer(float Horiz, float Vert)
    {

            moveDirSide = transform.right * Horiz;
            moveDirForward = transform.forward * Vert;

        tempMovementSpeed /= 2;

        charControl.SimpleMove(moveDirSide + moveDirForward);

        JumpInput();
    }

    void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        float airTime = 0;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(airTime);
            charControl.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            airTime += Time.deltaTime;
            yield return null;
        } while (!charControl.isGrounded && charControl.collisionFlags != CollisionFlags.Above);

        isJumping = false;
    }
}
