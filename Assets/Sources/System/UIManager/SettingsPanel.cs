/* SettingsPanel.cs

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
public class SettingsPanel : Panel
{
  public GameObject AudioImageOn, AudioImageOff, MusicImageOn, MusicImageOff, HapticImageOn, HapticImageOff;
  public override void init()
  {
    UIInputManager.soundToggle += SoundToggleChanged;
    UIInputManager.musicToggle += MusicToggleChanged;
    initPlayerPrefs();
  }
  
  void MusicToggleChanged()
  {
    if (!MusicImageOff || !MusicImageOn) return;

    if (AudioManager.Instance.isMusicPlaying) {
      MusicImageOff.SetActive(true);
      MusicImageOn.SetActive(false);
    }
    else {
      MusicImageOff.SetActive(false);
      MusicImageOn.SetActive(true);
    }
  }

  void SoundToggleChanged()
  {
    if (AudioManager.Instance.isAudioPlaying) {
        AudioImageOn.SetActive(false);
        AudioImageOff.SetActive(true);
    }
    else {
        AudioImageOn.SetActive(true);
        AudioImageOff.SetActive(false);
    }
  }

  public override void hide()
  {
    Print.PrintDebug("Settings panel is deactivated", PrintType.UI);
    this.gameObject.SetActive(false);
  }

  public override void show()
  {
    Print.PrintDebug("SettingsPanel panel is activated", PrintType.UI);
    this.gameObject.SetActive(true);
  }
  
  
  void initPlayerPrefs()
  {
    if (!AudioManager.Instance.isAudioPlaying && PlayerPrefsManager.Instance.HasKey("isAudioPlaying")) {
        AudioImageOn.SetActive(false);
        AudioImageOff.SetActive(true);
    }
    else {
        AudioImageOn.SetActive(true);
        AudioImageOff.SetActive(false);
    }

    if(!AudioManager.Instance.isMusicPlaying && PlayerPrefs.HasKey("isMusicPlaying")) {
        MusicImageOff.SetActive(true);
        MusicImageOn.SetActive(false);
    }
    else {
        MusicImageOff.SetActive(false);
        MusicImageOn.SetActive(true);
    }
  }

}
}
