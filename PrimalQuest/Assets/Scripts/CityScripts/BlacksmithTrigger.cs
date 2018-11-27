using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlacksmithTrigger : MonoBehaviour {

    public BlacksmithDialogue bsd;
    Collider collider;
    
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
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
