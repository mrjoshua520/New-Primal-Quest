using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslandNPCTrigger : MonoBehaviour
{
    public IslandNPCDialogue INPCD;
    GameObject player;
    Collider collider;
    GameObject log;
    QuestLog quest;
    Stats Stat;
    public bool second = false;
    Vector3 loadpos;

    void Start()
    {
        log = GameObject.Find("QuestLog");
        quest = log.GetComponent<QuestLog>();
        collider = GetComponent<Collider>();
        Stat = new Stats();
    }

    // Use this for initialization
    void OnTriggerEnter(Collider trigger)
    {
        Debug.Log(second);
        if (trigger.tag == "Player" && !second)
        {

            quest.ActivateIsland(); //Enables the button for this quest in the quest log
            collider.enabled = false;
            INPCD.setUp();
        }
        else if (trigger.tag == "Player" && second)
        {
            INPCD.toIsland();
            StartCoroutine(Wait2());
        }
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(10);


        player = GameObject.FindWithTag("Player");

        DontDestroyOnLoad(player);
        SceneManager.LoadScene(4);
        loadpos = new Vector3(210f, 10f, 567.5f);
        player.transform.position = loadpos;
    }


    public void turnOnCollider()
    {
        Debug.Log("Collider on");
        collider.enabled = true;
    }
}
