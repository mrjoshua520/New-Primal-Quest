using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentDamage : MonoBehaviour
{
    Stats playerStats;
    GameObject player;
    public float distanceToPlayer;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = new Stats();
    }

    private void OnEnable()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer <= 5)
        {
            playerStats.DeductHealth(10);
        }
    }
}
