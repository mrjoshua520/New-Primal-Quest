using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Class_Selection : MonoBehaviour
{
    GameObject player;
    public GameObject mage;
    //public GameObject archer;
    public GameObject warrior;
    Vector3 loadpos;
    static string Class;
    
    public void Archer()
    {
        mage.SetActive(false);
        //archer.SetActive(true);
        warrior.SetActive(false);
        Class = "Archer";
        player = GameObject.Find("Archer");

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(1);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }

    public void Mage()
    {
        mage.SetActive(true);
        //archer.SetActive(true);
        warrior.SetActive(false);
        Class = "Mage";
        player = GameObject.Find("Mage");

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(1);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }

    public void Warrior()
    {
        mage.SetActive(false);
        //archer.SetActive(false);
        warrior.SetActive(true);
        Class = "Warrior";
        player = GameObject.Find("Warrior");

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(1);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }

    public string setClass()
    {
        return Class;
    }
}
