using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithTrigger : MonoBehaviour {

    public BlacksmithAnimation bsa;
   

    void Start()
    {
        bsa = FindObjectOfType<BlacksmithAnimation>();
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("inside trigger player");



            StartCoroutine(bsa.blacksmithAnimation());

            //if (onTriggerBlSm == true)
            //{
                //Debug.Log("inside trigger player");
                //StartCoroutine(bsa.blacksmithAnimation());
            //}

        }
    }
}
