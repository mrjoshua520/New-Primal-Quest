using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaKill : MonoBehaviour
{
    Stats stat;

    private void Start()
    {
        stat = new Stats();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stat.DeductHealth(500);
        }
    }
}
