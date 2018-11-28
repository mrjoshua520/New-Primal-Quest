using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlacksmithTrigger : MonoBehaviour {

    public BlacksmithDialogue bsd;
    GameObject log;
    QuestLog quest;
    Collider collider;
    
    void Start()
    {
        log = GameObject.Find("QuestLog");
        quest = log.GetComponent<QuestLog>();
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            quest.ActivateCave(); //This activates the quest in the quest log
            Debug.Log("inside trigger player");

            collider.enabled = false;
            
            bsd.disableMovementAndSetUpForDialogue();
        }
    }

    public IEnumerator turnOnCollider()
    {
        Debug.Log("In turn of collider");
        // to wait for blacksmith to walk away from character
        yield return new WaitForSeconds(10);
        collider.enabled = true;
        Debug.Log("After turn on collider");
    }
}
