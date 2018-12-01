using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerDialogue : MonoBehaviour
{

    EnemyAI enemyAI;
    public VillagerTrigger vt;
    GameObject player;
    Animator anim;
    GameObject text;
    PlayerHUD pHUD;
    Stats stats;
    bool talkedToKnight2 = false;

   
    
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        anim = GetComponent<Animator>();
        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<PlayerHUD>();
        stats = new Stats();

    }

    public void disableMovementAndSetUpForDialogue()
    {
        if (gameObject.name == "Knight2" && !talkedToKnight2)
        {
            Debug.Log("inside disable movement");
            enemyAI.wander = false;
            Debug.Log("inside disable movement: after wander equals false");

            player = GameObject.FindGameObjectWithTag("Player");
            transform.LookAt(player.transform);

            anim.SetBool("isWalking", false);
            Debug.Log("inside disable movement: after anim, before cor");
            StartCoroutine(villagerDialogue());
        }
        
    }

    public IEnumerator villagerDialogue()
    {
        if (gameObject.name == "Knight2")
        {
            pHUD.Dialogue("Knight", "Hello there. I just bought an amazing health potion from the alchemy shop. You should get some!");
            Debug.Log("After dialogue");

            yield return new WaitForSeconds(10);
            Debug.Log("After wait for seconds");

            talkedToKnight2 = true;
            enableMovement();
        }
    }

    void enableMovement()
    {
        Debug.Log("in enable movement");
        enemyAI.wander = true;
        //navmesh.enabled = true;

        Debug.Log("After enable movement");

        StartCoroutine(vt.turnOnCollider());
    }
}
