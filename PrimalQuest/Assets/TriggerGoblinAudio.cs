using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoblinAudio : MonoBehaviour
{
    public bool startTroll = false;
    public string[] sounds;
    public float delay = 1;
    public GameObject trollAudio = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(PlaySounds());
            if (startTroll)
            {
                trollAudio.GetComponent<DetectCollision>().isClose = true;
            }
        }
    }

    IEnumerator PlaySounds()
    {
        foreach (string sound in sounds)
        {
            FindObjectOfType<AudioManager>().Play(sound);
            yield return new WaitForSeconds(delay);
        }

        Destroy(this);
    }
}
