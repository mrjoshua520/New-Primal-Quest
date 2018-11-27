using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class FinalBossAITest : MonoBehaviour
{
    public GameObject[] waypoints;
    NavMeshAgent agent;
    GameObject player;
    Animator anim;
    Stats playerStats;
    bool wander = true;
    bool recentlyAttacked;
    float proximty = 25;
    int currentDestination = 0;

    [Header("Boss Stats")]
    public float health;
    public float damage;

    [Header("Boss Details")]
    public float distanceToPlayer;
    public float stopDistanceWhip = 12;
    public float stopDistance = 4;
    public float detectionRange = 30;
    public float timeToPause = 3;

    [HideInInspector]
    public bool isWaiting = false;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = new Stats();
        anim = GetComponent<Animator>();
        agent.stoppingDistance = stopDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {
            if (wander)
            {
                StartCoroutine(Wander(agent, anim, stopDistance, timeToPause));
            }
        }

        if (!wander)
        {
            transform.LookAt(player.transform.position - Vector3.up);
            SetTarget(agent, anim, player);
        }

        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer <= stopDistance)
        {
            Attack();
        }

        if (distanceToPlayer <= stopDistanceWhip && distanceToPlayer >= stopDistance)
        {
            WhipAttack();
        }

        if (distanceToPlayer >= stopDistanceWhip && distanceToPlayer <= proximty)
        {
            Follow();
        }
    }

    void Follow()
    {
        agent.speed = 5;
        ChangeAnimation("isWalking");
        SetTarget(agent, anim, player);
    }

    public void Attack()
    {
        wander = false;
        agent.speed = 0;
        SetTarget(agent, anim, player);
        ChangeAnimation("Attack");

        if (!recentlyAttacked)
        {
            StartCoroutine(DamagePlayerBasic(damage));
        }
    }

    public void WhipAttack()
    {
        wander = false;
        agent.speed = 0;
        SetTarget(agent, anim, player);
        ChangeAnimation("whipAttack");

        if (!recentlyAttacked)
        {
            StartCoroutine(DamagePlayerWhip(5f));
        }
    }

    IEnumerator DamagePlayerBasic(float damageAttack)
    {
        recentlyAttacked = true;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 4))
        {
            if (hit.transform.CompareTag("Player"))
            {
                playerStats.DeductHealth(damageAttack);
                yield return new WaitForSeconds(1);
            }
        }
        yield return new WaitForSeconds(.5f);
        recentlyAttacked = false;
    }

    IEnumerator DamagePlayerWhip(float damageAttack)
    {
        recentlyAttacked = true;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 12))
        {
            if (hit.transform.CompareTag("Player"))
            {
                playerStats.DeductHealth(damageAttack);
                //Drag Closer
                yield return new WaitForSeconds(1);
            }
        }
        yield return new WaitForSeconds(.5f);
        recentlyAttacked = false;
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
        ChangeAnimation("isDead");
        Destroy(gameObject, 5f);
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

    public void SetTarget(NavMeshAgent agent, Animator anim, GameObject target)
    {
        anim.SetBool("isWalking", true);
        agent.SetDestination(target.transform.position);
    }

    public IEnumerator Wander(NavMeshAgent agent, Animator anim, float turnDistance, float waitTime)
    {
        anim.SetBool("isWalking", true);

        if (Vector3.Distance(waypoints[currentDestination].transform.position, agent.transform.position) <= turnDistance)
        {
            isWaiting = true;
            anim.SetBool("isWalking", false);
            yield return new WaitForSeconds(waitTime);
            isWaiting = false;
            anim.SetBool("isWalking", true);

            currentDestination = Random.Range(0, waypoints.Length);
        }

        agent.SetDestination(waypoints[currentDestination].transform.position);
    }
}
