using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public BossAI bossAI;
    bool hasAttacked;
    public float timeToWait = .1f;

    private void OnTriggerEnter(Collider other)
    {
        if (hasAttacked)
            return;

        if (other.CompareTag("Player"))
            StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        hasAttacked = true;
        bossAI.DoDamage();
        yield return new WaitForSeconds(timeToWait);
        hasAttacked = false;
    }
}
