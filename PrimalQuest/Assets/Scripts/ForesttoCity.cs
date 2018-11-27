using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForesttoCity : MonoBehaviour
{

    GameObject player;
    Vector3 loadpos;
    GameObject PGUI;
    Transition trans;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.FindWithTag("Player");
            PGUI = GameObject.Find("Transition");
            trans = PGUI.GetComponent<Transition>();

            trans.FadeOut();
            DontDestroyOnLoad(player);
            SceneManager.LoadScene(1);
            loadpos = new Vector3(15f, 20f, 34f);
            player.transform.position = loadpos;
            trans.FadeIn();

        }
    }
}
