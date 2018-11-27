using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(1));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(2));
    }

    IEnumerator Fade(int x)
    {
        if (x == 1)
        {
            anim.SetInteger("FadeValue", 1);
        }
        else if (x == 2)
        {
            anim.SetInteger("FadeValue", 2);
        }
        yield return new WaitForSeconds(.6f);
        anim.SetInteger("FadeValue", 0);
    }
}
