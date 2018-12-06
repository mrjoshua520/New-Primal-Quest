using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinorDeath : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Destroy(player);
    }

    void Update ()
    {
		if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
	}
}
