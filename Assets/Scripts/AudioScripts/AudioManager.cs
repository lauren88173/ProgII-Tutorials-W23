using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    //List of sounds that can be added or removed and have properties

    public Sound[] audioClips;
    
    //Awake instead of start because its before start?
    void Awake()
    {
        foreach (Sound audio in audioClips)
        {
            //can call the play method on the audio source, easiest way to do this is to 
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.clip;

            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
        }
        
    }

    public void Play (string name)
    {
        //Allows me to find a sound from the sound array
        Sound audio = Array.Find(audioClips, sound => sound.title == name);
        audio.source.Play();
    }
   
}
