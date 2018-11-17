using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickupTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E key pressed");
            }
        }
    }
}
