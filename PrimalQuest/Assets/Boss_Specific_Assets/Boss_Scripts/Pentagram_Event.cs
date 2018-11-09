using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram_Event : MonoBehaviour
{
    Animator anim;
    public GameObject light;
    public GameObject circle;
    public GameObject pentagram;
    public GameObject pillar1;
    public GameObject pillar2;
    public GameObject pillar3;
    public Material color;
    bool triggered = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !triggered)
        {
            StartCoroutine(SpawnPortal());
        }
    }

    IEnumerator SpawnPortal()
    {
        pentagram.SetActive(true);

        light.SetActive(false);

        RenderSettings.skybox = color;

        yield return new WaitForSeconds(.5f);

        pillar1.SetActive(true);

        yield return new WaitForSeconds(1.25f);

        pillar2.SetActive(true);

        yield return new WaitForSeconds(1.25f);

        pillar3.SetActive(true);

        yield return new WaitForSeconds(5.5f);

        circle.SetActive(true);
    }
}
