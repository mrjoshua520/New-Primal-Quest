using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    // Use this for initialization
    Animator anim;
    bool isAttacking = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(Swing());
            isAttacking = false;
        }
    }

    IEnumerator Swing()
    {
        anim.SetBool("isAttack", true);

        yield return new WaitForSeconds(.40f);

        anim.SetBool("isAttack", false);
    }
}
