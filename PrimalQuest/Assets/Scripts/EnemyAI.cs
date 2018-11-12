using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{   // to use functions from movement do this:
    // public NPCMovement npcMovement;
    // in Update
    // if(!npcMovement.isWaiting)
    // {
    //    call functions from NPCMovement
    // }  
    

    NavMeshAgent agent;
    GameObject player;
    Animator anim;

    int range = 4;

    public NPCMovement npcMovement;
   
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) < range)
        {
            npcMovement.SetTarget(agent, anim, player);
            range = 100;
        }        
    }
}
