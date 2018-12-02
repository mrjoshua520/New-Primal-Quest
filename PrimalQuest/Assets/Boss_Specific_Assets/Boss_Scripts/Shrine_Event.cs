using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine_Event : MonoBehaviour
{
    public Material color;
    public GameObject light;

    private void OnTriggerEnter(Collider other)
    {
        light = GameObject.Find("IslandLight");

        light.SetActive(false);

        RenderSettings.skybox = color;
    }
}
