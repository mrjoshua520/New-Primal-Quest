using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BsmtihBuildingTrigger : MonoBehaviour
{

    public EnemyAI enemyAI;

    void Start()
    {
        enemyAI = FindObjectOfType<EnemyAI>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("inside trigger player");

            enemyAI.enabled = true;

        }
    }
}




//public CharacterController2 bscript;

//void Start()
//{
//    ascript = GetComponent<CharacterController1>();
//    bscript = GetComponent<CharacterController2>();
//    ascript.enabled = true;
//    bscript.enabled = false;
//}
//void Update()
//{
//    if (Input.GetKeyDown(KeyCode.Q))
//    {
//        if (ascript.enabled == true)
//        {
//            ascript.enabled = false;
//            bscript.enabled = true;
//        }
//        else
//        {
//            ascript.enabled = true;
//            bscript.enabled = false;
//        }
//    }
