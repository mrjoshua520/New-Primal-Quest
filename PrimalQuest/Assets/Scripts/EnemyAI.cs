using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    Animator anim;

    [Header("Enemy Stats")]
    public float damage;
    public float range = 5;
    public int accuracy;
    public int timetoPause;

    [Header("NPC Path Options")]
    public bool walkSetPath;
    public bool wander;
    public bool willChasePlayer;
   
    [Header("NPC Waypoints")]
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
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (willChasePlayer)
        {
            if (distanceToPlayer <= range)
            {
                wander = false;
                walkSetPath = false;
                npcMovement.SetTarget(agent, anim, player);
                range = Mathf.Infinity;

                if(distanceToPlayer <= agent.stoppingDistance)
                {
                    Attack();
                }
                else if(distanceToPlayer > agent.stoppingDistance)
                {
                    anim.SetBool("isAttacking", false);
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

    public void Attack()
    {
        anim.SetBool("isAttacking", true);
        transform.LookAt(player.transform.position);
    }
}
