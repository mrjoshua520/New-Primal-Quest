using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlchemyDialo : MonoBehaviour {

    EnemyAI enemyAI;
    NavMeshAgent navMesh;
    Animator anim;
    GameObject player;
    GameObject text;
    PlayerHUD pHUD;
	
	void Start ()
    {
        enemyAI = GetComponent<EnemyAI>();
        anim = GetComponent<Animator>();
        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<PlayerHUD>();
	}

    public void setUp()
    {
        enemyAI.enabled = false;
        navMesh.enabled = false;

        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        anim.SetBool("isWalking", false);
    }

    public void dialogue()
    {
        Debug.Log("Scripts working together");
        pHUD.Dialogue("Alchemist", "Hello Sir");
    }
	
	
}
