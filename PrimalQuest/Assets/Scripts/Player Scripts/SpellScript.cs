using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{

    public GameObject weapon;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireSpell());
        }
    }

    IEnumerator FireSpell()
    {
        weapon.SetActive(true);

        yield return new WaitForSeconds(5);

        weapon.SetActive(false);
    }
}
