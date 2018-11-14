using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Class_Selection : MonoBehaviour
{
    GameObject player;
    public GameObject mage;
    //public GameObject archer;
    //public GameObject warrior;
    Vector3 loadpos;
    
    public void Archer()
    {
        mage.SetActive(true);
        //archer.SetActive(true);
        //warrior.SetActive(true);

        player = GameObject.Find("Archer");

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(0);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }

    public void Mage()
    {
        mage.SetActive(true);
        //archer.SetActive(true);
        //warrior.SetActive(true);

        player = GameObject.Find("Mage");

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(0);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }

    public void Warrior()
    {
        mage.SetActive(true);
        //archer.SetActive(true);
        //warrior.SetActive(true);

        player = GameObject.Find("Warrior");

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(0);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }
}
