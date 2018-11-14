using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{

    public GameObject weapon;
    Animator anim;
    bool isAttacking = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireSpell());
        }
    }

    IEnumerator FireSpell()
    { 
        if (!isAttacking)
        {
            anim.SetBool("isAttack", true);

            yield return new WaitForSeconds(3);

            anim.SetBool("isAttack", false);
        }
    }
}
