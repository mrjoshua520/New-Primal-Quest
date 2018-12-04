using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Class_Selection : MonoBehaviour
{
    GameObject player;
    public GameObject mage;
    public GameObject archer;
    public GameObject warrior;
    public GameObject fadePanel;
    Animator anim;
    Stats stat;
    Vector3 loadpos;
    static string Class;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Archer();
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            Mage();
        }
        else if (Input.GetButtonDown("Collect"))
        {
            Warrior();
        }
    }

    public void Archer()
    {
        mage.SetActive(false);
        archer.SetActive(true);
        warrior.SetActive(false);
        Class = "Archer";
        stat = new Stats();
        stat.SetStatsArcher();
        player = GameObject.Find("Archer");

        StartCoroutine(Transition());
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

        StartCoroutine(Transition());
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

        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        fadePanel.SetActive(true);
        yield return new WaitForSeconds(.3f);
        anim.SetBool("fade", true);
        yield return new WaitForSeconds(2);
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(1);
        loadpos = new Vector3(120f, 18f, 1f);
        player.transform.position = loadpos;
    }

    public string setClass()
    {
        return Class;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
