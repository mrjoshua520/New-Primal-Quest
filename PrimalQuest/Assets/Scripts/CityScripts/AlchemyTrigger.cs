using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyTrigger : MonoBehaviour {

    public AlchemyDialo ALDI;
    Collider collider;
    GameObject player;
    PlayerMove quest;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        quest = player.GetComponent<PlayerMove>();
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
            ALDI.dialogue();

        }
    }
}
