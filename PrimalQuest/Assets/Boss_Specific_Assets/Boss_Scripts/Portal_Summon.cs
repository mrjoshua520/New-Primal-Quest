using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <Notes>
/// Need to add smooth transitions but this works for now
/// </Notes>

public class Portal_Summon : MonoBehaviour {

    GameObject Player;
    public GameObject portal;
    Vector3 loadpos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            portal.SetActive(true);
            StartCoroutine(teleport());
        }
    }

    IEnumerator teleport()
    {
        Player = GameObject.FindWithTag("Player");

        Player.transform.LookAt(portal.transform);

        yield return new WaitForSeconds(7f);

        DontDestroyOnLoad(Player);
        SceneManager.LoadScene(4);
        loadpos = new Vector3(15f, 20f, 34f);
        Player.transform.position = loadpos;
    }
}
