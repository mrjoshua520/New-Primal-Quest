using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour {


    Stats stat;
    public GameObject panel;
    public TextMeshProUGUI dialogue;
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
        Test();
	}

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Dialogue("Blacksmith", "Why hello there friend. This is a lovely test!!!");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Dialogue("None", "Why hello there mortal. This is a lovely test!!!");
        }
    }

    void DisplayHealth()
    {
        HP.text = "Health: " + stat.GetHPPerc().ToString();
    }

    public void Dialogue(string speaker, string text)
    {
        Debug.Log("Inside Dialogue");
        int textLength = text.Length; //Length of the text sent
        int speakerLength = speaker.Length; //Length of the speakers name

        if (speaker == "None")
        {
            //For Narration there is no speaker
            StartCoroutine(Display(text, textLength));
        }
        else
        {
            //For NPCs
            StartCoroutine(Display(speaker, text, speakerLength, textLength));
        }
    }

    IEnumerator Display(string speaker, string text, int speakerLength, int textLength)
    {
        char dispText;

        panel.SetActive(true);

        for (int i = 0; i < speakerLength; i++)
        {
            dispText = speaker[i];
            dialogue.text += "" + dispText.ToString();
            yield return new WaitForSeconds(.05f);
        }

        dialogue.text += ":";

        yield return new WaitForSeconds(.05f);

        dialogue.text += " ";

        yield return new WaitForSeconds(.05f);

        for (int i = 0; i < textLength; i++)
        {
            dispText = text[i];
            dialogue.text += "" + dispText.ToString();
            yield return new WaitForSeconds(.05f);
        }

        yield return new WaitForSeconds(5);
        dialogue.text = "";
        panel.SetActive(false);
    }

    IEnumerator Display(string text, int textLength)
    {
        char dispText;

        panel.SetActive(true);

        for (int i = 0; i < textLength; i++)
        {
            dispText = text[i];
            Debug.Log(dispText);
            dialogue.text += "" + dispText.ToString();
            yield return new WaitForSeconds(.05f);
        }

        yield return new WaitForSeconds(5);
        dialogue.text = "";
        panel.SetActive(false);
    }
}
