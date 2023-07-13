/* Sound.cs

    ----------------------------------------------------------------------
    Persephone

    Author : Özge Kocaoğlu 
* ------------------------------------------------------------------------ */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace Persephone
{

[Serializable]
public class Sound
{
  public AudioMixerGroup audioMixerGroup;
  AudioSource source;
  public string clipName;
  public AudioClip clip;
  
  [Range(0.3f, 1f)]
  public float volume = 1f;
  
  [Range(0.3f, 1f)]
  public float pitch = 1f;
  public bool Loop = false;
  public bool PlayOnAwake = false;
  
  public void SetSource(AudioSource audioSource)
  {
    source = audioSource;
    source.clip = clip;
    source.pitch = pitch;
    source.volume = volume;
    source.playOnAwake = PlayOnAwake;
    source.loop = Loop;
    source.outputAudioMixerGroup = audioMixerGroup;
  }  
  
  public void Play()
  {
    source.Play();
  }
  
  public void Stop()
  {
    source.Stop();
  }
  
  public void Mute()
  {
    source.mute = true;
  }

  public void UnMute()
  {
    source.mute = false;
  }
}
}
