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
    public AlchemyTrigger Trigger;

    PlayerHUD talkingBool;
    bool firstTime = true;
	
	void Start ()
    {
        enemyAI = GetComponent<EnemyAI>();
        anim = GetComponent<Animator>();
        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<PlayerHUD>();
	}

    public void setUp()
    {
        enemyAI.wander = false;
        //navMesh.enabled = false;

        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        anim.SetBool("isWalking", false);
        StartCoroutine(alchemyAnimation());
        //dialogue();
        
    }

    public void dialogue()
    {
        Debug.Log("Scripts working together");
        pHUD.Dialogue("Alchemist", "Hello there! If you're looking for a health potion I am sorry but I am sold out. Could you go to the forest and get the nine plants I need for more health potions. Theres a free potion if you help me. ");
    }

    public IEnumerable alchemyAnimation()
    {
        Debug.Log("inside blacksmith animation");

        if (firstTime)
        {
            pHUD.Dialogue("Alchemist", "Hello there! If you're looking for a health potion I am sorry but I am sold out. Could you go to the forest and get the nine plants I need for more health potions. Theres a free potion if you help me. ");
            Debug.Log("After dialogue");

            yield return new WaitForSeconds(10);
            Debug.Log("After wait for seconds");
            firstTime = false;
            enableMovement();
        }
        Debug.Log("after if first time");
    }
    void enableMovement()
    {
        Debug.Log("in enable movement");
        enemyAI.wander = true;
        //navmesh.enabled = true;

        Debug.Log("After enable movement");

        StartCoroutine(Trigger.turnOnCollider());
    }

}
