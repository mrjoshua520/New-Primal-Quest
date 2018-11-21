using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour {

    Stats stat;
    public TextMeshProUGUI HP;

	// Use this for initialization
	void Start ()
    {
        stat = new Stats();
	}
	
	// Update is called once per frame
	void Update ()
    {
        DisplayHealth();
	}

    void DisplayHealth()
    {
        HP.text = "Health: " + stat.GetHPPerc().ToString();
    }

    void Dialogue(string text)
    {

    }
}
