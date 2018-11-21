using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    bool Displayed = false;
    public GameObject panel;
    public GameObject hud;
    public GameObject main;
    public GameObject forest;
    public GameObject cave;
    public GameObject island;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Time.timeScale = 0;
            if (!Displayed)
            {
                Displayed = true;
                hud.SetActive(false);
                main.SetActive(true);
                panel.SetActive(true);
                forest.SetActive(false);
                cave.SetActive(false);
                island.SetActive(false);
            }
            else
            {
                Displayed = false;
                hud.SetActive(true);
                panel.SetActive(false);
                main.SetActive(false);
                forest.SetActive(false);
                cave.SetActive(false);
                island.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (Displayed)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
