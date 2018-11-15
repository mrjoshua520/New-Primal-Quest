using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Temp
using UnityEngine.SceneManagement;

public class WarriorMove : MonoBehaviour
{
    WarriorStats player;
    CharacterController charControl;
    Vector3 move = Vector3.zero;
    float gravity = 30f;

    // Use this for initialization
    void Start()
    {
        player = new WarriorStats();
        charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        TestingSpell();
        TempToIsland();
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
        }
    }

    void TempToIsland()
    {
        GameObject player1;
        Vector3 loadpos;

        if (Input.GetButtonDown("Fire3"))
        {
            player1 = GameObject.FindWithTag("Player");
            DontDestroyOnLoad(player1);
            SceneManager.LoadScene(4);
            loadpos = new Vector3(202f, 9f, 567f);
            player1.transform.position = loadpos;
        }
    }
}

