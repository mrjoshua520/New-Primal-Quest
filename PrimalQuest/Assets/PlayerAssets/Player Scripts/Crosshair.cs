using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public void OnGUI()
    {
        float xMin = (Screen.width / 2);
        float yMin = (Screen.height / 2);
        GUI.Box(new Rect(xMin, yMin, 10, 10), "");
    }
}
