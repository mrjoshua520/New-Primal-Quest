using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlacksmithDialogue: MonoBehaviour
{
    EnemyAI enemyAI;
    public BlacksmithTrigger bst;
    GameObject player;
    Animator anim;
    GameObject text;
    PlayerHUD pHUD;
    Stats stats;

    string firstTimeDialogue = "Oh hey there, I'm sorry I can't sell you anything right now, I'm too busy with something. A fellow villager just got taken by a group of goblins. I heard from the guards that they were held up in the cave not too far from here. I'm too old to be fighting goblins, please help me!";
    string villagerSavedDialogue = "Thank you for saving the villager!";


    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        anim = GetComponent<Animator>();
        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<PlayerHUD>();
        stats = new Stats();

    }

    public void disableMovementAndSetUpForDialogue()
    {
        Debug.Log("inside disable movement");
        enemyAI.wander = false;

        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        anim.SetBool("isWalking", false);

        StartCoroutine(blacksmithAnimation());
    }

    public IEnumerator blacksmithAnimation()
    {
        Debug.Log("inside blacksmith animation");
        bool complete = stats.GetCave();

        if (!complete)
        {
            pHUD.Dialogue("Blacksmith", firstTimeDialogue);
            Debug.Log("After dialogue");

            yield return new WaitForSeconds(30);
            Debug.Log("After wait for seconds");
    
            enableMovement();
        }
        else if (complete)
        {
            pHUD.Dialogue("Blacksmith", villagerSavedDialogue);
            yield return new WaitForSeconds(15);
            enableMovement();
        }
    }


    void enableMovement()
    {
        Debug.Log("in enable movement");
        enemyAI.wander = true;
        //navmesh.enabled = true;

        Debug.Log("After enable movement");

        StartCoroutine(bst.turnOnCollider());
    }


   
}



