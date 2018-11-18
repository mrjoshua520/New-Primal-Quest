using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{

    Animator anim;
    bool isAttacking = false;
    RaycastHit hitInfo;
    Camera camera;
    float range = 25f;
    EnemyAI enemy;
    Stats stat;

    private void Start()
    {
        anim = GetComponent<Animator>();
        camera = GetComponent<Camera>();
        enemy = new EnemyAI();
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
                enemy.DeductHealth(stat.GetDamage());
            }
        }
    }
}
