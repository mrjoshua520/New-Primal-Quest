using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithTrigger : MonoBehaviour {

    BlacksmithAnimation bsa;
    //public bool onTriggerBlSm;

    void Start()
    {
        bsa = FindObjectOfType<BlacksmithAnimation>();
        //onTriggerBlSm = true;
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
