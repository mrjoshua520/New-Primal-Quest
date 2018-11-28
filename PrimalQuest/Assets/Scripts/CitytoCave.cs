using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CitytoCave : MonoBehaviour
{
    GameObject player;
    Vector3 loadpos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.FindWithTag("Player");

            DontDestroyOnLoad(player);
            SceneManager.LoadScene(3);
            loadpos = new Vector3(-78.5f, 1.5f, -108f);
            player.transform.position = loadpos;
        }
    }
}
