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
    Stats Stat;

    PlayerHUD talkingBool;
    bool firstTime = true;
    bool firstTimeComp = true;
	
	void Start ()
    {
        enemyAI = GetComponent<EnemyAI>();
        anim = GetComponent<Animator>();
        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<PlayerHUD>();
        Stat = new Stats();
	}

    public void setUp()
    {
        enemyAI.wander = false;
        //navMesh.enabled = false;

        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        anim.SetBool("isWalking", false);
        StartCoroutine(alchemyAnimation());
    }

    public void potionGive()
    {
        enemyAI.wander = false;
        //navMesh.enabled = false;

        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

        anim.SetBool("isWalking", false);
        StartCoroutine(givePotion());
    }

    IEnumerator alchemyAnimation()
    {
        Debug.Log("inside blacksmith animation");

        if (firstTime && !VillagerDialogue.currentlyTalking)
        {
            pHUD.Dialogue("Alchemist", "Hello there! If you're looking for a health potion I am sorry but I am sold out. Could you go to the forest and get the nine plants I need for more health potions. Theres a free potion if you help me. ");
            Debug.Log("After dialogue");

            yield return new WaitForSeconds(10);
            Debug.Log("After wait for seconds");
            firstTime = false;
            enableMovement();
            Trigger.turnOnCollider();
        }
        Trigger.turnOnCollider();
        Debug.Log("after if first time");
    }

    IEnumerator givePotion()
    {
        Debug.Log("inside blacksmith animation");

        if (firstTimeComp && !VillagerDialogue.currentlyTalking)
        {
            pHUD.Dialogue("Alchemist", "Ah, the plants. With these I can get back to work making potions for Kreton. Here's the free one I promised you. Make sure to put it to good use.");
            Stat.SetSpec(1); //Gives the player the potion
            Debug.Log("After dialogue");

            yield return new WaitForSeconds(10);
            Debug.Log("After wait for seconds");
            firstTimeComp = false;
            enableMovement();
            Trigger.turnOnCollider();
        }
        Trigger.turnOnCollider();
        Debug.Log("after if first time");
    }

    void enableMovement()
    {
        Debug.Log("in enable movement");
        enemyAI.wander = true;
        //navmesh.enabled = true;

        Debug.Log("After enable movement");
    }

}
