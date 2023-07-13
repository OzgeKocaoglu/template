/* PlayerPrefsManager.cs

    ----------------------------------------------------------------------
    Persephone

    Author : Özge Kocaoğlu 
* ------------------------------------------------------------------------ */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Persephone
{
public class PlayerPrefsManager: SingletonManager<PlayerPrefsManager>
{
  PlayerSaveData playerData;
  
  public PlayerPrefsManager()
  {
    playerData = new PlayerSaveData();
  }

  public void AwakePlayerPrefsManager()
  {
    IntiliazePlayerPrefs();
  }
  
  public void IntiliazePlayerPrefs()
  {
    AudioManager.Instance.isAudioPlaying = playerData.audioOn;
    AudioManager.Instance.audioMasterVolume = playerData.audioMasterVolume;
    AudioManager.Instance.isMusicPlaying = playerData.musicOn;
    AudioManager.Instance.musicMasterVolume = playerData.musicMasterVolume;
  }
  
  public void SaveAudioPlayerPrefs(bool _audioOn, float volume)
  {
    playerData.audioOn = _audioOn;
    playerData.audioMasterVolume = volume;
  }

  public void SaveMusicPlayerPrefs(bool _musicOn, float volume)
  {
    playerData.musicOn = _musicOn;
    playerData.musicMasterVolume = volume;
  }

  public void SaveHapticManagerPrefs(bool isActive)
  {
    playerData.hapticOn = isActive;
  }

  public bool HasKey(string key)
  {
    return PlayerPrefs.HasKey(key);
  }
}
}
