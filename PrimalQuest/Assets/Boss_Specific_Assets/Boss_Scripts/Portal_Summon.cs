using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// <Notes>
/// Need to add smooth transitions but this works for now
/// </Notes>

public class Portal_Summon : MonoBehaviour {

    public GameObject Player;
    public GameObject portal;
    Vector3 dir;
    Quaternion rot;

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
        Player.transform.LookAt(portal.transform);

        yield return new WaitForSeconds(7f);

        SceneManager.LoadScene(4);
    }
}
