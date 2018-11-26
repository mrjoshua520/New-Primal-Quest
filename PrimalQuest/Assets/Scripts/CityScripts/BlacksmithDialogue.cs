using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlacksmithDialogue: MonoBehaviour
{
    EnemyAI enemyAI;
    NavMeshAgent navmesh;


    GameObject player;
    Animator anim;
    GameObject text;
    PlayerHUD pHUD;


    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        navmesh = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<PlayerHUD>();

    }

    public void disableMovementAndSetUpForDialogue()
    {
        enemyAI.enabled = false;
        navmesh.enabled = false;

        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        anim.SetBool("isWalking", false);

    }

    public void blacksmithDialogue()
    {
        Debug.Log("inside blacksmith dialogue");
        
        pHUD.Dialogue("Blacksmith", "This is a test");
    }


    public IEnumerator blacksmithAnimation()
    {
        //enemyAI.enabled = false;
        Debug.Log("inside animation");

        pHUD.Dialogue("Blacksmith", "This is a test");

        Debug.Log("After dialogue");


        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        Debug.Log("After look at");

        anim.SetBool("isWalking", false);
        yield return new WaitForSeconds(10);

        Debug.Log("After wait for seconds");
        //anim.SetBool("isSweating", true);
        //yield return new WaitForSeconds(2);
        //anim.SetBool("isSweating", false);
        //yield return new WaitForSeconds(7);
        //anim.SetBool("isWorking", false);

        //bst.onTriggerBlSm = true;

    }

    public void idlStateAfterTriggerWithPlayer()
    {
        anim.SetBool("isWalking", false);
        Debug.Log("Walking FALSE");
    }

}



