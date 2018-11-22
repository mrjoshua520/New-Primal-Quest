using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithAnimation : MonoBehaviour {

    Animator anim;
    public BlacksmithTrigger bst;

    GameObject text;
    HUD pHUD;



    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        //bst = GetComponent<BlacksmithTrigger>();
        bst = FindObjectOfType<BlacksmithTrigger>();

        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<HUD>();



        //StartCoroutine(blacksmithAnimation());
    }

    public IEnumerator blacksmithAnimation()
    {
        //bst.onTriggerBlSm = false;

        Debug.Log("inside animation");
        
        text.Dialogue(“Blacksmith”, “This is a test.”);

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
