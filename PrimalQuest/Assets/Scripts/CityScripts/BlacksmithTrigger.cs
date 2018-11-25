using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithTrigger : MonoBehaviour {

    public BlacksmithAnimation bsa;
    EnemyAI enemyAI;
    Collider collider;
    
    
    void Start()
    {
        //bsa = FindObjectOfType<BlacksmithAnimation>();
        enemyAI = GetComponent<EnemyAI>();
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("inside trigger player");

            //GetComponent<Collider>().isTrigger = false;
            collider.enabled = false;
            enemyAI.enabled = false;

            //blacksmithDialogue();
            StartCoroutine(bsa.blacksmithAnimation());
        }
    }
}
