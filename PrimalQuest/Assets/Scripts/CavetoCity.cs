using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CavetoCity : MonoBehaviour
{

    GameObject player;
    Vector3 loadpos;
    public GameObject trans;

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
        loadpos = new Vector3(305f, 20f, 34f);
        player.transform.position = loadpos;
    }
}
