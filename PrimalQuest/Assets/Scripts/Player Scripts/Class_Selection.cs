using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Class_Selection : MonoBehaviour
{
    GameObject player;
    //public GameObject mage;
    //public GameObject archer;
    //public GameObject warrior;
    Vector3 loadpos;
    
    public void Archer()
    {
        player = GameObject.Find("Archer");

        player.SetActive(true);

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(0);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }

    public void Mage()
    {
        player = GameObject.Find("Mage");

        player.SetActive(true);

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(0);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }

    public void Warrior()
    {
        player = GameObject.Find("Warrior");

        player.SetActive(true);

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(0);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }
}
