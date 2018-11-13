using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{

    public float mouseSensitivity;
    public Transform PlayerBody;
    float mouseY;
    float mouseX;
    float rotateAmountX;
    float rotateAmountY;
    Vector3 targetRotCam;
    Vector3 targetRotBody;

    float xAxisClamp = 0;

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RotateCamera();
    }

    void RotateCamera()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotateAmountX = mouseX * mouseSensitivity;
        rotateAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotateAmountY;

        targetRotCam = transform.rotation.eulerAngles;
        targetRotBody = PlayerBody.rotation.eulerAngles;

        targetRotCam.x -= rotateAmountY;
        targetRotCam.z = 0;
        targetRotBody.y += rotateAmountX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = -90;
        }

        transform.rotation = Quaternion.Euler(targetRotCam);
        PlayerBody.rotation = Quaternion.Euler(targetRotBody);

    }
}
