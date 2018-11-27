using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyTrigger : MonoBehaviour {

    public AlchemyDialo ALDI;
    Collider collider;

	void Start ()
    {
        collider = GetComponent<Collider>();
	}
	
	
    void OnTriggerEnter(Collider trigger)
    {
        if(trigger.tag == "Player")
        {
            Debug.Log("Player inside alchemy shop");
            collider.enabled = false;

        }
    }
}
