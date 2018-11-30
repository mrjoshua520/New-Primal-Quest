using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IslandAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public float stopDistance;
    bool wait = false;
    float distanceToPlayer;
    Animator anim;
    public GameObject waitPoint;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (wait)
        {
            agent.SetDestination(waitPoint.transform.position);

            if (transform.position == waitPoint.transform.position)
            {
                anim.SetBool("isWalking", false);
                transform.LookAt(player.transform);
            }
            else
            {
                anim.SetBool("isWalking", true);
            }
        }
        else
        {
            if (distanceToPlayer <= 4)
            {
                anim.SetBool("isWalking", false);
                agent.speed = 0;
                StartCoroutine(Wait());
            }
            else
            {
                anim.SetBool("isWalking", true);
                agent.SetDestination(player.transform.position);
            }
        }
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        wait = true;
        agent.speed = 3.5f;
    }
}
