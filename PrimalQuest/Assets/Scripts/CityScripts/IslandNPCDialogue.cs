using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandNPCDialogue : MonoBehaviour
{
    GameObject player;
    GameObject text;
    PlayerHUD pHUD;
    public IslandNPCTrigger Trigger;
    Stats Stat;
    PlayerHUD talkingBool;
    bool firstTime = true;
    bool firstTimeComp = true;

    // Use this for initialization
    void Start()
    {
        text = GameObject.Find("HUD");
        pHUD = text.GetComponent<PlayerHUD>();
        Stat = new Stats();
    }

    public void setUp()
    {
        StartCoroutine(FirstTalk());
    }

    public void toIsland()
    {
        StartCoroutine(letsGo());
    }

    IEnumerator FirstTalk()
    {
        if (firstTime)
        {
            pHUD.Dialogue("Strange Lady", "Hey you! I've heard you've been helping out around here. There's a pretty big problem happening over on the island Chalok. Interested? Well meet me at the docks if you are.");
            yield return new WaitForSeconds(5);
            firstTime = false;
            Trigger.turnOnCollider();
        }
        Trigger.turnOnCollider();
    }

    IEnumerator letsGo()
    {
        if (firstTimeComp)
        {
            pHUD.Dialogue("Strange Lady", "I thought you might show up. I'll cut right to the chase with this, some local priests have heard about strange portals opening up on the island. They want someone to go take care of it. Let's not waste any time, i'll take you to the island.");
            yield return new WaitForSeconds(7);
            firstTimeComp = false;
        }
    }
}
