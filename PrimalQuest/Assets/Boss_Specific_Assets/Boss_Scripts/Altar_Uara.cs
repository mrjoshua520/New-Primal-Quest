using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar_Uara : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Collect"))
            {
                //Choose Uara
            }
        }
    }
}
