using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithAnimation : MonoBehaviour {

    Animator anim;
    GameObject text;
    PlayerHUD pHUD;

    void Start ()
    {
        anim = GetComponent<Animator>();
        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<PlayerHUD>();
    }

    public IEnumerator blacksmithAnimation()
    {
        //bst.onTriggerBlSm = false;

        Debug.Log("inside animation");
        
        //pHUD.Dialogue("Blacksmith", "This is a test");

        Debug.Log("After dialogue");

        anim.SetBool("isWalking", false);
        yield return new WaitForSeconds(5);
        anim.SetBool("isWorking", true);
        yield return new WaitForSeconds(7);
        anim.SetBool("isSweating", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("isSweating", false);
        //yield return new WaitForSeconds(7);
        //anim.SetBool("isWorking", false);

        //bst.onTriggerBlSm = true;

    }
}
