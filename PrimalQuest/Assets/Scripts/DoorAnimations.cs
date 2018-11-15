using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    Animator anim;
   
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
    }

    //void Update()
    //{
    //    anim.SetBool("open", false);
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("open", true);

            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    anim.SetBool("open", true);
            //}
            //else
            //{
            //    anim.SetBool("open", false);
            //}
        }
    }

    
}
