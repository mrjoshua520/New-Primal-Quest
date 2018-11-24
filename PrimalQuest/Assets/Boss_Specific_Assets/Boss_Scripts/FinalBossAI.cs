using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAI : MonoBehaviour
{
    Animator anim;
    GameObject player;
    public bool Begin = false;
    bool Combat = false;
    float distanceToPlayer;
    float Timer;

    [Header("Boss Stats")]
    public float health;
    public float damage;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Timer = 0;
    }

    void Update ()
    {
        if (!Begin && !Combat)
        {
            transform.LookAt(player.transform);
        }

		if (Begin)
        {
            anim.SetBool("Begin", true);
            Begin = false;
            Combat = true;
        }
         
        if (Combat)
        {
            if (distanceToPlayer <= 5)
            {
                if (Timer >= 5f)
                {
                    //Player was too close for too long
                    //Explosion and then fly to pillar
                    //Summon Things and wait for them to be dead
                }
                else
                {
                    //Keep Attacking with sword
                }
            }
            else if (distanceToPlayer > 5)
            {
                if (Timer >= 5f)
                {
                    //Whip Attack
                    //Drag Player Closer
                }
                else
                {
                    //Walk to Player
                }
            }
            else if (distanceToPlayer > 10)
            {
                //too far away get closer walk
                if (Timer < 5f)
                {
                    //walk to player
                }
                else
                {
                    //Fly to player
                }
            }
        }
	}
}
