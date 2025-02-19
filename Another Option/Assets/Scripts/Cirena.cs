using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cirena : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sound;

    public void Play()
    {
        source.loop = true;
        source.clip = sound;
        source.Play();
    }
    public void Stop()
    {
        source.loop = false;
        source.clip = null;
        source.Stop();
    }
}
