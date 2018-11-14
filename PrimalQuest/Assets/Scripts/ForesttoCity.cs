using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForesttoCity : MonoBehaviour
{

    GameObject player;
    Vector3 loadpos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.FindWithTag("Player");
            DontDestroyOnLoad(player);
            SceneManager.LoadScene(0);
            loadpos = new Vector3(15f, 20f, 34f);
            player.transform.position = loadpos;
        }
    }
}
