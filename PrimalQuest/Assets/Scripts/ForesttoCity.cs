using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForesttoCity : MonoBehaviour
{

    GameObject player;
    public GameObject trans;
    Vector3 loadpos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.FindWithTag("Player");

            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        trans.SetActive(true);
        yield return new WaitForSeconds(2);
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(1);
        loadpos = new Vector3(15f, 20f, 34f);
        player.transform.position = loadpos;
        FindObjectOfType<AudioManager>().Stop("forest_music");
        FindObjectOfType<AudioManager>().Play("city_music");
    }
}
