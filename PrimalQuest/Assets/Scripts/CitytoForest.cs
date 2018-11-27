using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CitytoForest : MonoBehaviour
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
            loadpos = new Vector3(239f, 2f, 230f);
            player.transform.position = loadpos;
            SceneManager.LoadScene(2);
            trans.FadeIn();
        }
    }
}
