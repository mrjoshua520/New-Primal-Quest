using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar_Drak : MonoBehaviour
{
    Stats stat;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject Active;

    private void Start()
    {
        stat = new Stats();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            light1.SetActive(true);
            light2.SetActive(true);
            light3.SetActive(true);
            light4.SetActive(true);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Collect"))
            {
                stat.SetSpec(3);
                Active.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            light1.SetActive(false);
            light2.SetActive(false);
            light3.SetActive(false);
            light4.SetActive(false);
            Active.SetActive(false);
        }
    }
}
