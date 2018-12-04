using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Select;
    public GameObject help;
    public GameObject main;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Select.SetActive(true);
            main.SetActive(false);
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            help.SetActive(true);
            main.SetActive(false);
        }
        else if (Input.GetButtonDown("Collect"))
        {
            Application.Quit();
        }
    }
}
