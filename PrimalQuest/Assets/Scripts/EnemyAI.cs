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
        if (willChasePlayer)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= range)
            {
                if (wander)
                {
                    wander = false;
                    npcMovement.SetTarget(agent, anim, player);
                    if (Vector3.Distance(player.transform.position, transform.position) > range)
                    {
                        wander = true;
                    }
                }

                else if (walkSetPath)
                {
                    walkSetPath = false;
                    npcMovement.SetTarget(agent, anim, player);
                    if (Vector3.Distance(player.transform.position, transform.position) > range)
                    {
                        walkSetPath = true;
                    }
                }
            }
        }

        if (!npcMovement.isWaiting)
        {
            if (walkSetPath && !wander)
            {
               StartCoroutine(npcMovement.SetPath(agent, anim, accuracy, timetoPause));
            }

            else if (wander && !walkSetPath)
            {
                StartCoroutine(npcMovement.Wander(agent, anim, accuracy, timetoPause));
            }

            else if (wander && walkSetPath)
            {
                Debug.LogError("Please check either walksetpath or wander you cannot check both;");
            }
        }
    }
}
