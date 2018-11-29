using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CitytoIslandTemp : MonoBehaviour
{

    GameObject player;
    Vector3 loadpos;
    Stats Stat;

    private void Start()
    {
        Stat = new Stats();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool forest = Stat.GetForest();
        bool cave = Stat.GetCave();

        if (other.tag == "Player" && forest && cave)
        {
            player = GameObject.FindWithTag("Player");

            DontDestroyOnLoad(player);
            SceneManager.LoadScene(4);
            loadpos = new Vector3(210f, 10f, 567.5f);
            player.transform.position = loadpos;
        }
    }
}
