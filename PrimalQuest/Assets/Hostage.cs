using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hostage : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public HostageTrigger ht;
    GameObject player;
    GameObject text;
    PlayerHUD pHUD;
    Stats stats;
    bool saved = false;
   
    public GameObject escapeWaypoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<PlayerHUD>();
        stats = new Stats();
    }

    public IEnumerator hostageDialogue()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        pHUD.Dialogue("Theobald", "Thank you for saving me from these beasts. They had me locked up here for hours and I had no way of escaping. I will be forever thankful. I gotta hurry back to town!"); 
        yield return new WaitForSeconds(10);
        saved = true;
        stats.doneCave();

        //yield return new WaitForSeconds(1);
        //gameObject.SetActive(false);
        Destroy(gameObject, 1);
    }
       
    
    void Update ()
    {
        if (saved == true)
        {
            anim.SetBool("isWalking", true);
            agent.SetDestination(escapeWaypoint.transform.position);
        }
	}
}
