using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlchemyTrigger : MonoBehaviour {

    public AlchemyDialo ALDI;
    Collider collider;
    GameObject log;
    QuestLog quest;

	void Start ()
    {
        log = GameObject.Find("QuestLog");
        quest = log.GetComponent<QuestLog>();
        collider = GetComponent<Collider>();

	}
	
	
    void OnTriggerEnter(Collider trigger)
    {
        if(trigger.tag == "Player")
        {
            Debug.Log("Player inside alchemy shop");
            quest.ActivateForest(); //Enables the button for this quest in the quest log
            collider.enabled = false;
            ALDI.setUp();
            //ALDI.dialogue();

        }
    }

    public IEunmerator turnOnCollider()
    {
        yield return new WaitForSeconds(10);
        collider.enabled = true;
    }
}
