using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickupTrigger : MonoBehaviour {

    Stats stat;

	// Use this for initialization
	void Start ()
    {
        stat = new Stats();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Collect"))
            {
                Debug.Log("E key pressed");
                Destroy(gameObject);
                stat.PlantPickup();
            }
        }
    }
}
