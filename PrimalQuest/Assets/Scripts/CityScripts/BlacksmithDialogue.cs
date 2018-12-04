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
    bool endOfDialogue = false;

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

        if (!complete && !endOfDialogue)
        {
            pHUD.Dialogue("Blacksmith", "Oh hey there, I'm sorry I can't sell you anything right now, I'm too busy with something. A fellow villager just got taken by a group of goblins. I heard from the guards that they were held up in the cave not too far from here. I'm too old to be fighting goblins, please help me!");
            Debug.Log("After dialogue");

            yield return new WaitForSeconds(30);
            Debug.Log("After wait for seconds");
    
            enableMovement();
        }
        else if (complete && !endOfDialogue)
        {
            pHUD.Dialogue("Blacksmith", "Thank you for saving the villager! I was working on a way to help you out. Here's my grandfather's old necklace. I don't need it much these days but it really helps you hit a little harder.");
            endOfDialogue = true;
            stats.ChangeDamage(20);
            stats.SetSpec(2);
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



