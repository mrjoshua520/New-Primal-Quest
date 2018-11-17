using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    Animator anim;
    PlayerMove playerStats;

    [Header("Enemy Stats")]
    public int health = 50;
    public int damage = 10;
    public float detectionRange = 5;
    public int stopDistance;
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
        playerStats = player.GetComponent<PlayerMove>();
        anim = GetComponent<Animator>();
        agent.stoppingDistance = stopDistance;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (willChasePlayer)
        {
            if (distanceToPlayer <= detectionRange)
            {
                wander = false;
                walkSetPath = false;
                npcMovement.SetTarget(agent, anim, player);
                detectionRange = Mathf.Infinity;

                if(distanceToPlayer <= stopDistance)
                {
                    Attack();
                }
                else if(distanceToPlayer > stopDistance)
                {
                    anim.SetBool("isAttacking", false);
                }
            }
        }

        if (!npcMovement.isWaiting)
        {
            if (walkSetPath && !wander)
            {
               StartCoroutine(npcMovement.SetPath(agent, anim, stopDistance, timetoPause));
            }

            else if (wander && !walkSetPath)
            {
                StartCoroutine(npcMovement.Wander(agent, anim, stopDistance, timetoPause));
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

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, stopDistance))
        {
            if(hit.transform.CompareTag("Player"))
            {
                playerStats.player.DeductHealth(damage);
            }          
        }      
    }

    public void DeductHealth(int _damage)
    {
        health -= _damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        agent.isStopped = true;
        anim.SetBool("isDead", true);
        Destroy(gameObject, 5f);
    }
}
