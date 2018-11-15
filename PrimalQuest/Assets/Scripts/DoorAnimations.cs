using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimations : MonoBehaviour
{

    Vector3 player;
    Vector3 bigHouseDoor;
    Animator anim;
   // Vector3 alchemyDoor;
    //Vector3 blacksmithDoor;

	// Use this for initialization
	void Start ()
    {
        bigHouseDoor = GameObject.Find("BigHouseDoor1").transform.position;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;

        checkDistanceToOpen();
        
	}

    void checkDistanceToOpen()
    {
        if (Vector3.Distance(player, bigHouseDoor) < 100)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetBool("open", true);
            }

            anim.SetBool("open", false);
        }
    }
}
