using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerTrigger : MonoBehaviour
{
    Collider collider;
    public VillagerDialogue vd;
    
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !VillagerDialogue.currentlyTalking)
        {
            Debug.Log("inside trigger player");

            collider.enabled = false;
            vd.disableMovementAndSetUpForDialogue();
        }
    }

    public IEnumerator turnOnCollider()
    {
        Debug.Log("In turn of collider");
        // to wait for villager to walk away from character
        yield return new WaitForSeconds(10);
        collider.enabled = true;
        Debug.Log("After turn on collider");
    }
}
