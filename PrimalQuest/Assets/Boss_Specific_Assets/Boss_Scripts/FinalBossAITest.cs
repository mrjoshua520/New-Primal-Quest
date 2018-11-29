using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class FinalBossAITest : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject pullLoc;
    public GameObject flyHeight;
    public GameObject landing;
    public GameObject pillar1;
    public GameObject pillar2;
    public GameObject pillar3;
    public GameObject burst1;
    public GameObject burst2;
    public GameObject burst3;
    public GameObject burst4;
    public GameObject burst5;
    public GameObject burst6;
    public GameObject burst7;
    public GameObject burst8;
    NavMeshAgent agent;
    GameObject player;
    Animator anim;
    Stats playerStats;
    bool wander = true;
    bool recentlyAttacked;
    float proximty = 25;
    int currentDestination = 0;

    bool chosen = false;
    int pillar = 0;
    bool done = false;
    bool done2 = false;
    bool onPillar = false;
    bool afterburst = false;
    bool landed = false;
    bool endStage = false;
    bool didstage2 = false;
    bool didstage3 = false;

    //Stages==========
    bool stage2 = false;
    bool stage3 = false;
    //================

    [Header("Boss Stats")]
    public float health;
    public float damage;

    [Header("Boss Details")]
    public float distanceToPlayer;
    public float stopDistanceWhip = 12;
    public float stopDistance = 4;
    public float detectionRange = 30;
    public float timeToPause = 3;
    bool Death = false;

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
        if (Death == false)
        {
            if (!stage2 && !stage3)
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
            else if (stage2 && !stage3)
            {
                if (endStage)
                {
                    agent.enabled = true;
                    chosen = false;
                    pillar = 0;
                    done = false;
                    done2 = false;
                    onPillar = false;
                    afterburst = false;
                    landed = false;
                    endStage = false;
                    didstage2 = true;
                    stage2 = false;
                }
                else
                {
                    int pillar = ChoosePillar();
                    Debug.Log(pillar);

                    if (!onPillar)
                    {
                        ChangeAnimation("isFlight");
                        agent.enabled = false;

                        if (done)
                        {
                            if (pillar == 1)
                            {
                                StartCoroutine(flyPillar(pillar1));
                            }
                            else if (pillar == 2)
                            {
                                StartCoroutine(flyPillar(pillar2));
                            }
                            else
                            {
                                StartCoroutine(flyPillar(pillar3));
                            }
                        }
                        else
                        {
                            StartCoroutine(flyUp(flyHeight));
                        }
                    }
                    else
                    {
                        if (afterburst)
                        {
                            ChangeAnimation("isFlight");
                            if (done2)
                            {
                                StartCoroutine(flyland(landing));

                                if (landed)
                                {
                                    endStage = true;
                                }
                            }
                            else
                            {
                                StartCoroutine(flyUptwo(flyHeight));
                            }
                        }
                        else
                        {
                            StartCoroutine(RoarDamage());
                        }
                    }
                }
            }
            else if (!stage2 && stage3)
            {
                if (endStage)
                {
                    agent.enabled = true;
                    chosen = false;
                    pillar = 0;
                    done = false;
                    done2 = false;
                    onPillar = false;
                    afterburst = false;
                    landed = false;
                    endStage = false;
                    didstage3 = true;
                    stage3 = false;
                }
                else
                {
                    int pillar = ChoosePillar();
                    Debug.Log(pillar);

                    if (!onPillar)
                    {
                        ChangeAnimation("isFlight");
                        agent.enabled = false;

                        if (done)
                        {
                            if (pillar == 1)
                            {
                                StartCoroutine(flyPillar(pillar1));
                            }
                            else if (pillar == 2)
                            {
                                StartCoroutine(flyPillar(pillar2));
                            }
                            else
                            {
                                StartCoroutine(flyPillar(pillar3));
                            }
                        }
                        else
                        {
                            StartCoroutine(flyUp(flyHeight));
                        }
                    }
                    else
                    {
                        if (afterburst)
                        {
                            ChangeAnimation("isFlight");
                            if (done2)
                            {
                                StartCoroutine(flyland(landing));

                                if (landed)
                                {
                                    endStage = true;
                                }
                            }
                            else
                            {
                                StartCoroutine(flyUptwo(flyHeight));
                            }
                        }
                        else
                        {
                            StartCoroutine(RoarDamage());
                        }
                    }
                }
            }
        }
        else
        {
            Die();
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
                yield return new WaitForSeconds(1f);
                player.transform.position = pullLoc.transform.position;
            }
        }
        yield return new WaitForSeconds(.5f);
        recentlyAttacked = false;
    }

    public void DeductHealth(int _damage)
    {
        health -= _damage;
        detectionRange = Mathf.Infinity;

        Debug.Log(health);

        if (health <= 100 && !didstage2)
        {
            stage2 = true;
        }
        else if (health <= 50 && !didstage3)
        {
            stage3 = true;
        }
        else if (health <= 0)
        {
            Debug.Log("Dying");
            Death = true;
        }
    }

    void Die()
    {
        agent.isStopped = true;
        ChangeAnimation("isDead");
        Destroy(gameObject, 5f);
    }

    int ChoosePillar()
    {
        if (!chosen)
        {
            pillar = Random.Range(1, 4);

            chosen = true;
        }
        return pillar;
    }

    IEnumerator flyUp(GameObject dest)
    {
        while (transform.position != dest.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest.transform.position, .1f * Time.deltaTime);
            // Wait a frame and move again.
            yield return null;
        }
        done = true;
    }

    IEnumerator flyPillar(GameObject dest)
    {
        while (transform.position != dest.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest.transform.position, .1f * Time.deltaTime);
            // Wait a frame and move again.
            yield return null;
        }
        onPillar = true;
    }

    IEnumerator flyUptwo(GameObject dest)
    {
        while (transform.position != dest.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest.transform.position, .1f * Time.deltaTime);
            // Wait a frame and move again.
            yield return null;
        }
        done2 = true;
    }

    IEnumerator flyland(GameObject dest)
    {
        while (transform.position != dest.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest.transform.position, .1f * Time.deltaTime);
            // Wait a frame and move again.
            yield return null;
        }
        landed = true;
    }

    IEnumerator RoarDamage()
    {
        int burst;
        transform.LookAt(player.transform);
        ChangeAnimation("Begin");
        yield return new WaitForSeconds(.75f);
        anim.SetBool("Begin", false);
        burst = Random.Range(1, 9);
        pillarActivate(burst);
        yield return new WaitForSeconds(3);

        afterburst = true;
    }

    void pillarActivate(int burst)
    {
        Debug.Log(burst);
        if (burst == 1)
        {
            burst1.SetActive(true);
        }
        else if (burst == 2)
        {
            burst2.SetActive(true);
        }
        else if (burst == 3)
        {
            burst3.SetActive(true);
        }
        else if (burst == 4)
        {
            burst4.SetActive(true);
        }
        else if (burst == 5)
        {
            burst5.SetActive(true);
        }
        else if (burst == 6)
        {
            burst6.SetActive(true);
        }
        else if (burst == 7)
        {
            burst7.SetActive(true);
        }
        else if (burst == 8)
        {
            Debug.Log("in 8");
            burst8.SetActive(true);
        }
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
