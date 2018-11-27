﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Class_Selection : MonoBehaviour
{
    GameObject player;
    public GameObject mage;
    public GameObject archer;
    public GameObject warrior;
    Stats stat;
    Vector3 loadpos;
    static string Class;
    GameObject PGUI;
    Transition trans;

    public void Archer()
    {
        mage.SetActive(false);
        archer.SetActive(true);
        warrior.SetActive(false);
        Class = "Archer";
        stat = new Stats();
        stat.SetStatsArcher();
        player = GameObject.Find("Archer");
        PGUI = GameObject.Find("Transition");
        trans = PGUI.GetComponent<Transition>();

        trans.FadeOut();
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(1);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
        trans.FadeIn();
    }

    public void Mage()
    {
        mage.SetActive(true);
        archer.SetActive(true);
        warrior.SetActive(false);
        Class = "Mage";
        stat = new Stats();
        stat.SetStatsMage();
        player = GameObject.Find("Mage");
        PGUI = GameObject.Find("Transition");
        trans = PGUI.GetComponent<Transition>();

        trans.FadeOut();
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(1);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
        trans.FadeIn();
    }

    public void Warrior()
    {
        mage.SetActive(false);
        archer.SetActive(false);
        warrior.SetActive(true);
        Class = "Warrior";
        stat = new Stats();
        stat.SetStatsWarrior();
        player = GameObject.Find("Warrior");
        PGUI = GameObject.Find("Transition");
        trans = PGUI.GetComponent<Transition>();

        trans.FadeOut();
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(1);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
        trans.FadeIn();
    }

    public string setClass()
    {
        return Class;
    }
}
