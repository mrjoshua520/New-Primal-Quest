using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithAnimation : MonoBehaviour {

    Animator anim;


	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	


	// Update is called once per frame
	void Update ()
    {
        while (true)
        {
            anim.SetBool("isWalking", false);
        }
	}
}
