using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hostage : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    public bool saved = false;
   
    public GameObject escapeWaypoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (saved == true)
        {
            agent.SetDestination(escapeWaypoint.transform.position);
        }
	}
}
