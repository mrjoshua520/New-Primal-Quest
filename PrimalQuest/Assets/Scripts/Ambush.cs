using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambush : MonoBehaviour
{
    public GameObject spawnPoint1;
    public GameObject spawnPoint2 = null;
    public GameObject enemyPrefab;
    public int enemyCount;
    public int spawnRate = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(enemyPrefab, spawnPoint1.transform.position, Quaternion.identity);
                if (spawnPoint2 != null)
                {
                    Instantiate(enemyPrefab, spawnPoint2.transform.position, Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnRate);
            }         
        }
}
