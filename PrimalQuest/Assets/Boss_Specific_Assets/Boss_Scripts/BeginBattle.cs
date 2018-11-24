using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBattle : MonoBehaviour
{

    public GameObject demon;
    public GameObject trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            demon.GetComponent<FinalBossAI>().Begin = true;
            trigger.SetActive(false);
        }
    }
}
