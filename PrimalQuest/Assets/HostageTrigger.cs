using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageTrigger : MonoBehaviour
{
    Collider collider;
    public Hostage hostage;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collider.enabled = false;
            StartCoroutine(hostage.hostageDialogue());
        }
    }
}
