using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlacksmithDialogue: MonoBehaviour
{
    EnemyAI enemyAI;
    NavMeshAgent navmesh;
    public BlacksmithTrigger bst;


    GameObject player;
    Animator anim;
    GameObject text;
    PlayerHUD pHUD;
    bool firstTime = true;


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
        Debug.Log("inside disable movement");
        enemyAI.enabled = false;
        //navmesh.enabled = false;

        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        anim.SetBool("isWalking", false);

        //blacksmithDialogue();
        StartCoroutine(blacksmithAnimation());
    }

    void blacksmithDialogue()
    {
        Debug.Log("inside blacksmith dialogue");

        if (firstTime)
        {
            pHUD.Dialogue("Blacksmith", "Oh hey there, I'm sorry I can't sell you anything right now, I'm too busy with something. My daughter just got taken by a group of goblins. I heard from the guards that they were held up in the cave not too far from here. I'm too old to be fighting goblins, please help me!");

            enableMovement();
        }

       
    }


    void enableMovement()
    {
        Debug.Log("in enable movement");
        enemyAI.enabled = true;
        navmesh.enabled = true;

        Debug.Log("After enable movement");

        StartCoroutine(bst.turnOnCollider());
    }


    public IEnumerator blacksmithAnimation()
    {

        Debug.Log("inside blacksmith animation");

        if (firstTime)
        {
            //pHUD.Dialogue("Blacksmith", "Oh hey there, I'm sorry I can't sell you anything right now, I'm too busy with something. My daughter just got taken by a group of goblins. I heard from the guards that they were held up in the cave not too far from here. I'm too old to be fighting goblins, please help me!");
            Debug.Log("After dialogue");
            yield return new WaitForSeconds(10);
            Debug.Log("After wait for seconds");
            enableMovement();
        }

       //nim.SetBool("isWalking", false);
       // yield return new WaitForSeconds(10);

        
       
    }

    public void idlStateAfterTriggerWithPlayer()
    {
        anim.SetBool("isWalking", false);
        Debug.Log("Walking FALSE");
    }

}



