using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour {

    Animator anim;
    bool isAttacking = false;
    RaycastHit hitInfo;
    Camera camera;
    float range = 50f;
    EnemyAI enemy;
    FinalBossAITest Demon;
    Stats stat;

    public GameObject arrowPrefab;


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

        Damage();

        yield return new WaitForSeconds(.48f);

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
        }
    }
}
