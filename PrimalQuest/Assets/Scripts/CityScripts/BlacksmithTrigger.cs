using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlacksmithTrigger : MonoBehaviour {

    public BlacksmithDialogue bsd;
    //public EnemyAI enemyAI;
    Collider collider;
    //GameObject player;
    //NavMeshAgent nav;



    void Start()
    {
        //bsa = FindObjectOfType<BlacksmithAnimation>();
        //enemyAI = GetComponent<EnemyAI>();
        collider = GetComponent<Collider>();
        //nav = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("inside trigger player");

            collider.enabled = false;
            //enemyAI.wander = false;
            //enemyAI.enabled = false;
            //player = GameObject.Find("Blacksmith");
            //player.GetComponent<NavMeshAgent>().enabled = false;



            //nav.enabled = false;

            bsd.disableMovementAndSetUpForDialogue();



            //blacksmithDialogue();
            //StartCoroutine(bsd.blacksmithAnimation());

            //bsa.idlStateAfterTriggerWithPlayer();

            //bsa.blacksmithDialogue();
        }
    }
}
