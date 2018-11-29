﻿using UnityEngine.Audio;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

	// Use this for initialization
	void Awake () {

        DontDestroyOnLoad(gameObject);

		foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    void Start()
    {
        //For when we have music to play in the background
        //Play();
    }
	
	public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");

            return;
        }
            
        s.source.Play();
    }

    // Add this line in the scripts we wanna call the audiomanager
    // FindObjectOfType<AudioManager>().Play("The name in audiomanager");
}