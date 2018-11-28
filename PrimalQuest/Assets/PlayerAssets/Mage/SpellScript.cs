using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{

    Animator anim;
    bool isAttacking = false;
    Camera camera;
    float range = 25f;
    EnemyAI enemy;
    FinalBossAITest Demon;
    BossAI Troll;
    Stats stat;

    private void Start()
    {
        anim = GetComponent<Animator>();
        camera = GetComponent<Camera>();
       
        stat = new Stats();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(Fire());
            isAttacking = false;
        }
    }

    IEnumerator Fire()
    {
        anim.SetBool("isAttack", true);

        yield return new WaitForSeconds(1);

        Damage();

        anim.SetBool("isAttack", false);
    }

    void Damage()
    {
        RaycastHit hitInformation;
        //shoot a ray from the cameras current position
        //shoot it the way that the camera is facing

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInformation, range))
        {
            //Debug.Log(hitInformation.transform.tag);

            string targetHit = hitInformation.transform.tag;

            if (targetHit == "Enemy")
            {
                enemy = hitInformation.collider.gameObject.GetComponent<EnemyAI>();
                enemy.DeductHealth(stat.GetDamage());
            }
            else if (targetHit == "Demon")
            {
                Demon = hitInformation.collider.gameObject.GetComponent<FinalBossAITest>();
                Demon.DeductHealth(stat.GetDamage());
            }
            else if (targetHit == "Troll")
            {
                Troll = hitInformation.collider.gameObject.GetComponent<BossAI>();
                Troll.DeductHealth(stat.GetDamage());
            }
        }
    }
}
