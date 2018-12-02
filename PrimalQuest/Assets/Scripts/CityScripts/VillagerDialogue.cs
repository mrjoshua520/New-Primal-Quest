﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerDialogue : MonoBehaviour
{

    EnemyAI enemyAI;
    public VillagerTrigger vt;
    GameObject player;
    Animator anim;
    GameObject text;
    PlayerHUD pHUD;
    Stats stats;
    bool talkedToKnight = false;
    bool talkedToKnight2 = false;
    bool talkedToKnight3 = false;
    bool talkedToArcher = false;

    //The player was chosen by the thirteen gods to be their champion in the coming war with the Primordial Beast.In choosing them the gods set the player outside of the small town to begin their adventure in helping them.The player was chosen due to certain traits that they possessed



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
        if ((gameObject.name == "Knight" && !talkedToKnight) || (gameObject.name == "Knight2" && !talkedToKnight2) || (gameObject.name == "Knight3" && !talkedToKnight3) || (gameObject.name == "Archer" && !talkedToArcher))
        {
            Debug.Log("inside disable movement");
            enemyAI.wander = false;
            Debug.Log("inside disable movement: after wander equals false");

            player = GameObject.FindGameObjectWithTag("Player");
            transform.LookAt(player.transform);

            anim.SetBool("isWalking", false);
            Debug.Log("inside disable movement: after anim, before cor");
            StartCoroutine(villagerDialogue());
        }
        
    }

    public IEnumerator villagerDialogue()
    {
        if (gameObject.name == "Knight")
        {
            pHUD.Dialogue("Wolfgang", "Hey there. A few days ago, I had bought a health potion from the alchemy shop. If I hadn't bought it when I did, I wouldn't be alive right now. You should get some before she sells out!");
            yield return new WaitForSeconds(13);
            talkedToKnight = true;
            enableMovement();
        }
        else if (gameObject.name == "Knight2")
        {
            pHUD.Dialogue("Percival", "I've been looking for my fellow neigbor, but I haven't seen him around. I'm getting worried something bad has happened to him. I can't leave my post, but can you talk to the blacksmith from me? He is good friends with him and might know something. ");
            yield return new WaitForSeconds(25);
            talkedToKnight2 = true;
            enableMovement();
        }
        else if (gameObject.name == "Knight3")
        {
            pHUD.Dialogue("Milo Rolfe", "Have you heard the news going around town? A war has started on Island Chalok, and no one has come back alive. I don't know who we are fighting, and I don't want to find out!");
            yield return new WaitForSeconds(20);
            talkedToKnight3 = true;
            enableMovement();
        }
        else if (gameObject.name == "Archer")
        {
            pHUD.Dialogue("Reina Forester", "I wouldn't go into the forest if I were you. Last time I went into the forest, I barely made it out.");
            yield return new WaitForSeconds(14);
            talkedToArcher = true;
            enableMovement();
        }
    }

    void enableMovement()
    {
        Debug.Log("in enable movement");
        enemyAI.wander = true;
        
        Debug.Log("After enable movement");

        StartCoroutine(vt.turnOnCollider());
    }
}