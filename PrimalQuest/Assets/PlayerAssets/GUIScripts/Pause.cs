using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool Displayed = false;
    public GameObject panel;
    public GameObject quest;
    public GameObject hud;
    public GameObject help;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            if (!Displayed)
            {
                Displayed = true;
                panel.SetActive(true);
                hud.SetActive(false);
                quest.SetActive(false);
                help.SetActive(false);
            }
            else
            {
                Displayed = false;
                hud.SetActive(true);
                quest.SetActive(true);
                panel.SetActive(false);
                help.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (Displayed)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                Quit();
            }
            else if (Input.GetButtonDown("Jump"))
            {
                help.SetActive(true);
                panel.SetActive(false);
            }

            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
