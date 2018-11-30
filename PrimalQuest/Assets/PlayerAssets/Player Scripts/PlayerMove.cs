using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector]
    public Stats player;
    CharacterController charControl;
    Vector3 move = Vector3.zero;
    float gravity = 30f;

    // Use this for initialization
    void Start()
    {
        player = new Stats();
        charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        TestingSpell();
        TEMPREADY();
    }

    void MovePlayer()
    {
        if (charControl.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move);
            move *= player.GetSpeed();

            if (Input.GetButtonDown("Jump"))
            {
                move.y = player.GetJump();
            }
        }

        move.y -= gravity * Time.deltaTime;

        charControl.Move(move * Time.deltaTime);
    }

    void TestingSpell()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            player.ChangeJump(30f);
            player.ChangeSpeed(30f);
            player.ChangeDamage(50);
        }
    }

    void TEMPREADY()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            player.READYTEMP();
        }
    }
}
