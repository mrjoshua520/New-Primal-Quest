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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "TownAI")
        {
            StartCoroutine(DoorDelay());
        }
    }

    IEnumerator DoorDelay()
    {
        anim.SetBool("open", true);
        yield return new WaitForSeconds(3);
        anim.SetBool("open", false);
    }
}
