using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour {

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
            StartCoroutine(Fire());
            isAttacking = false;
        }
    }

     IEnumerator Fire()
    {
        anim.SetBool("isAttack", true);

        yield return new WaitForSeconds(.48f);

        anim.SetBool("isAttack", false);
    }
}
