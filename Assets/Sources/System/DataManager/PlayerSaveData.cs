/* PlayerSaveData.cs

    ----------------------------------------------------------------------
    Gravedigger

    Author : Özge Kocaoğlu 
* ------------------------------------------------------------------------ */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Persephone
{
public class PlayerSaveData
{
  bool _audioOn = true;
  float _audioMasterVolume = 1f;
  bool _musicOn = true;
  float _musicMasterVolume = 1f;
  bool _hapticOn = true;
  int level = 1;

  public bool audioOn
  {
    get {
      if (!PlayerPrefs.HasKey("isAudioPlaying")) return _audioOn;
        return PlayerPrefs.GetInt("isAudioPlaying") == 1 ? true : false;
    }
    set {
      _audioOn = value;
      PlayerPrefs.SetInt("isAudioPlaying", _audioOn ? 1 : 0); 
    }
  }

  public float audioMasterVolume
  {
    get {
      if (!PlayerPrefs.HasKey("audioMasterVolume")) return _audioMasterVolume;
        return PlayerPrefs.GetFloat("audioMasterVolume");
    }
    set  {
      _audioMasterVolume = value;
      PlayerPrefs.SetFloat("audioMasterVolume", _audioMasterVolume);
    }
  }
  
  public bool musicOn
  {
    get {
      if (!PlayerPrefs.HasKey("isMusicPlaying")) return _musicOn;
        return PlayerPrefs.GetInt("isMusicPlaying") == 1 ? true : false;
    }
    set {
      _musicOn = value;
      PlayerPrefs.SetInt("isMusicPlaying", _musicOn ? 1 : 0);
    }
  }

  public float musicMasterVolume
  {
    get {
      if (!PlayerPrefs.HasKey("musicMasterVolume")) return _musicMasterVolume;
        return PlayerPrefs.GetFloat("musicMasterVolume");
    }
    set {
      _musicMasterVolume = value;
      PlayerPrefs.SetFloat("musicMasterVolume", _musicMasterVolume);
    }
  }
   
  public bool hapticOn
  {
    get {
      if (!PlayerPrefs.HasKey("isHapticActive")) return _hapticOn;
      return PlayerPrefs.GetInt("isHapticActive") == 1 ? true : false;
    }
    set {
      _hapticOn = value;
      PlayerPrefs.SetInt("isHapticActive", _hapticOn ? 1: 0);
    }
  }

  public int currentLevel
  {
    get {
      if (!PlayerPrefs.HasKey("level")) return level;
        return PlayerPrefs.GetInt("level");
    }
    set {
      level = value;
      PlayerPrefs.SetInt("level", level);
    }
  }
  
}
}
