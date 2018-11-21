using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    Animator anim;
    //PlayerMove playerStats;
    DeleteThisScript playerStats;
    bool wander = true;
    bool recentlyAttacked;
    bool charging = false;
    float distanceToPlayer;

    [Header("Boss Stats")]
    public float health;
    public float damage;

    [Header("Boss Details")]
    public float stopDistance = 4;
    public float detectionRange = 10;
    public float timeToPause = 3;

    public BossMovement movement;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        //playerStats = player.GetComponent<PlayerMove>();
        playerStats = player.GetComponent <DeleteThisScript>();
        anim = GetComponent<Animator>();
        agent.stoppingDistance = stopDistance;
    }
	
	// Update is called once per frame
	void Update ()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

       
       if(distanceToPlayer <= detectionRange && distanceToPlayer >= detectionRange /2)
       {
           Charge();
       }

       if (distanceToPlayer <= stopDistance && charging)
       {
           anim.SetBool("isRunning", false);
           anim.SetBool("useRunningAttack", true);
           charging = false;
            StartCoroutine(ComboAttack());
       }

        else if(distanceToPlayer <= detectionRange/2 && !charging)
       {
            wander = false;
            movement.SetTarget(agent, anim, player);
       }

       else if (distanceToPlayer <= stopDistance && !charging)
       {
            Attack();
       }

        if (!movement.isWaiting)
        {
            if (wander)
            {
                StartCoroutine(movement.Wander(agent, anim, stopDistance, timeToPause));
            }
        }
    }

    public void Attack()
    {
        wander = false;
        agent.speed = 3.5f;
        movement.SetTarget(agent, anim, player);
        anim.SetBool("useAttack", true);  
        if (distanceToPlayer > stopDistance)
        {
            anim.SetBool("useBacisAttack", false);
        }
    }

    public void Charge()
    {
        wander = false;
        charging = true;
        movement.SetTarget(agent, anim, player);
        agent.speed = 7;
        anim.SetBool("isRunning", true);       
    }

    public IEnumerator ComboAttack()
    {
        agent.speed = 3.5f;

        yield return new WaitForSeconds(1);
       
        anim.SetBool("useComboAttack", true);
        
        if(distanceToPlayer > stopDistance)
        {
            anim.SetBool("useComboattack", false);
        }
    }

    public void DoDamage()
    {
        playerStats.Damage(damage);
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
        agent.isStopped = true;
        anim.SetBool("isDead", true);
        Destroy(gameObject, 5f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}


