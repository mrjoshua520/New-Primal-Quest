using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject help;
    public GameObject main;

	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Fire3"))
        {
            help.SetActive(false);
            main.SetActive(true);
        }
	}
}
