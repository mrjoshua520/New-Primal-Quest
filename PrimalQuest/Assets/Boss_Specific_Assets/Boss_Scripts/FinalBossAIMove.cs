using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalBossAIMove : MonoBehaviour
{
    public GameObject[] waypoints;

    [HideInInspector]
    public bool isWaiting = false;

    int currentDestination = 0;

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
