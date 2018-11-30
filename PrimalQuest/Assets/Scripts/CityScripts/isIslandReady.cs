using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isIslandReady : MonoBehaviour
{
    Stats stat;
    public GameObject trigger;
    EnemyAI AIscript;
    IslandAI newAI;

	// Use this for initialization
	void Start ()
    {
        stat = new Stats();
        AIscript = GetComponent<EnemyAI>();
        newAI = GetComponent<IslandAI>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool forest = stat.GetForest();
        bool cave = stat.GetCave();
        bool ready = stat.ready();

        if (ready)
        {
            trigger.SetActive(true);
            AIscript.enabled = false;
            newAI.enabled = true;
        }
	}
}
