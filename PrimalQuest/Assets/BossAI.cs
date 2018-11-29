using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    Animator anim;
    Animator doorAnim;
    GameObject log; //These both are for the quest log
    QuestLog quest;//----^
    PlayerMove playerStats;
    bool wander = true;
    bool recentlyAttacked;
    bool charging = false;
    bool alive = true;
    float distanceToPlayer;
    float proximty = 8;

    [Header("Boss Stats")]
    public float health;
    public float damage;

    [Header("Boss Details")]
    public float stopDistance = 4;
    public float detectionRange = 10;
    public float timeToPause = 3;

    public BossMovement movement;
    public GameObject hostageDoor;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerMove>();
        anim = GetComponent<Animator>();
        agent.stoppingDistance = stopDistance;
        log = GameObject.Find("QuestLog");
        quest = log.GetComponent<QuestLog>();
        doorAnim = hostageDoor.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (alive)
        {
            if (!movement.isWaiting)
            {
                if (wander)
                {
                    StartCoroutine(movement.Wander(agent, anim, stopDistance, timeToPause));
                }
            }

            if (!wander)
            {
                transform.LookAt(player.transform.position - Vector3.up);
                movement.SetTarget(agent, anim, player);
            }

            distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);


            if (distanceToPlayer <= detectionRange && distanceToPlayer >= proximty)
            {
                Charge();
            }

            if (distanceToPlayer <= proximty - 4 && charging)
            {
                ChangeAnimation("useRunningAttack");
                StartCoroutine(ComboAttack());
            }

            if (distanceToPlayer <= stopDistance && !charging)
            {
                Attack();
            }

            if (distanceToPlayer >= stopDistance && distanceToPlayer <= proximty && !charging)
            {
                Follow();
            }
        }
    }

    void Follow()
    {
        ChangeAnimation("isWalking");
        movement.SetTarget(agent, anim, player);
    }

    public void Attack()
    {
        wander = false;
        agent.speed = 3.5f;
        movement.SetTarget(agent, anim, player);
        ChangeAnimation("useBasicAttack");
    }

    public void Charge()
    {
        wander = false;
        charging = true;
        movement.SetTarget(agent, anim, player);
        agent.speed = 9;
        ChangeAnimation("isRunning");     
    }

    public IEnumerator ComboAttack()
    {
        agent.speed = 3.5f;
        yield return new WaitForSeconds(1);
        ChangeAnimation("useComboAttack");
        yield return new WaitForSeconds(1);
        charging = false;
        Attack();
    }

    public void DoDamage()
    {
        playerStats.player.DeductHealth(damage);
    }

    public void DeductHealth(int _damage)
    {
        health -= _damage;
        detectionRange = Mathf.Infinity;

        if (health <= 0)
        {
            Debug.Log("Dying");
            Die();
        }
    }

    void Die()
    {
        alive = false;
        doorAnim.SetBool("open", true);
        agent.isStopped = true;
        anim.SetBool("isDead", true);      
        quest.CaveComplete();

        Destroy(gameObject, 7f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }

    public void ChangeAnimation(string animParameter)
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.SetBool(parameter.name, false);
        }

        anim.SetBool(animParameter, true);
    }
}


