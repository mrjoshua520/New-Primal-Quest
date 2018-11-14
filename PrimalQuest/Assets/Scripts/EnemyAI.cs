using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{   
    NavMeshAgent agent;
    GameObject player;
    Animator anim;

    public int range = 5;
    public int accuracy;
    public int timetoPause;

    public bool walkSetPath;
    public bool wander;
    public bool willChasePlayer;
   
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
        if (!npcMovement.isWaiting)
        {
            if (willChasePlayer)
            {
                if (Vector3.Distance(player.transform.position, this.transform.position) < range)
                {
                    npcMovement.SetTarget(agent, anim, player);
                }
            }

            else if (walkSetPath && !wander)
            {
                npcMovement.SetPath(agent, anim, accuracy, timetoPause);
            }

            else if (wander && !walkSetPath)
            {
                npcMovement.Wander(agent, anim, accuracy, timetoPause);
            }

            else if (wander && walkSetPath)
            {
                Debug.LogError("Please check either walksetpath or wander you cannot check both;");
            }
        }
    }
}
