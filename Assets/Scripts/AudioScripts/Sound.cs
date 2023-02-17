using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound {

    public string title;
    public AudioClip clip;

    //Min and max values of the below parameters
    [Range(0f, 30f)]
    public float volume;
    [Range(.1f, 5f)]
    public float pitch;

    //hideInInspector hides public variables
    [HideInInspector]
    public AudioSource source;
  
}
