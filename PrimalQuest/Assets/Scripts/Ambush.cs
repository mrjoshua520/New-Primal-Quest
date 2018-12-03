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
    bool alreadyActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!alreadyActivated)
            {
                StartCoroutine(Spawn());
            }           
        }
    }

    IEnumerator Spawn()
        {
            
            alreadyActivated = true;
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(enemyPrefab, spawnPoint1.transform.position, Quaternion.identity);
                if (spawnPoint2 != null)
                {
                    Instantiate(enemyPrefab, spawnPoint2.transform.position, Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnRate);
            }
            FindObjectOfType<AudioManager>().Play("Goblin_Babbling");
    }
}
