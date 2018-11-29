using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlchemyTrigger : MonoBehaviour {

    public AlchemyDialo ALDI;
    Collider collider;
    GameObject log;
    QuestLog quest;
    Stats Stat;

	void Start ()
    {
        log = GameObject.Find("QuestLog");
        quest = log.GetComponent<QuestLog>();
        collider = GetComponent<Collider>();
        Stat = new Stats();
	}
	
	
    void OnTriggerEnter(Collider trigger)
    {
        bool complete = Stat.GetForest();
        if(trigger.tag == "Player" && !complete)
        {
            Debug.Log("Player inside alchemy shop");
            quest.ActivateForest(); //Enables the button for this quest in the quest log
            collider.enabled = false;
            ALDI.setUp();
        }
        else if (complete)
        {
            ALDI.potionGive();
        }
    }


    public void turnOnCollider()
    {
        Debug.Log("Collider on");
        collider.enabled = true;
    }
}
