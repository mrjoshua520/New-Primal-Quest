using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAI : MonoBehaviour
{
    Animator anim;
    GameObject player;
    public bool Begin = false;
    public bool Combat = false;
    public float distanceToPlayer;
    public float Timer;

    [Header("Boss Stats")]
    public float health;
    public float damage;
    public float walkSpeed = 5f;
    public float flySpeed = 10f;

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
            if (Timer > 3)
            {
                anim.SetBool("Begin", false);
            }
            distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            transform.LookAt(player.transform);
            if (distanceToPlayer <= 4)
            {
                Timer += Time.deltaTime;
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
            else if (distanceToPlayer > 4)
            {
                Timer += Time.deltaTime;
                if (Timer >= 5f && distanceToPlayer < 8)
                {
                    RaycastHit hitInformation;
                    anim.SetBool("whipAttck", true);
                    if (Physics.Raycast(transform.position, transform.forward, out hitInformation, 8))
                    {
                        string targetHit = hitInformation.transform.tag;

                        if (targetHit == "Player")
                        {
                            player.transform.position += player.transform.forward * 4;
                        }
                    }
                    anim.SetBool("whipAttck", false);
                    Timer = 0;
                }
                else
                {
                    transform.position += transform.forward * walkSpeed * Time.deltaTime;
                }
            }
        }
	}
}
