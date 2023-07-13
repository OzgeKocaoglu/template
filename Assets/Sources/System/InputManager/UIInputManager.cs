/* UIInputManager.cs

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
/// <summary>
/// This class represents UI Inputs from player. 
/// These inputs are implements here whatever they are. 
/// </summary>
/// 
public class UIInputManager : InputManager
{
  public delegate void GameInput();
  public static GameInput playButton;
  public static GameInput pauseButton;
  public static GameInput resumeButton;
  public static GameInput homeButton;
  public static GameInput retryButton;
  public static GameInput nextLevelButton;
  public static GameInput preLevelButton;
  public static GameInput resetLevelButton;
  public static GameInput restartLevelButton;
  public static GameInput musicToggle;
  public static GameInput soundToggle;
  public void PauseButton()
  {
    Print.PrintDebug("Pause button clicked", PrintType.Input);
    pauseButton?.Invoke();
  }

  public void PlayButton()
  {
    Print.PrintDebug("Play button clicked", PrintType.Input);
    playButton?.Invoke();
  }

  public void HomeButton()
  {
    Print.PrintDebug("Home button clicked", PrintType.Input);
    homeButton?.Invoke();
  }

  public void RetryButton()
  {
    Print.PrintDebug("Retry button clicked", PrintType.Input);
    retryButton?.Invoke();
  }

  public void ResumeButton()
  {
    Print.PrintDebug("Resume button clicked", PrintType.Input);
    resumeButton?.Invoke();
  }

  public void NextLevelButton()
  {
    Print.PrintDebug("Next Level button clicked", PrintType.Input);
    nextLevelButton?.Invoke();
  }

  public void PreLevelButton()
  {
    Print.PrintDebug("Pre Level button clicked", PrintType.Input);
    preLevelButton?.Invoke();
  }

  public void ResetLevelButton()
  {
    Print.PrintDebug("Reset Levels button clicked", PrintType.Input);
    resetLevelButton?.Invoke();
  }

  public void RestartLevelButton()
  {
    Print.PrintDebug("Restart Level button clicked", PrintType.Input);
    restartLevelButton?.Invoke();
  }
  
  public void MusicToggle()
  {
    Print.PrintDebug("Music Toggle button clicked", PrintType.Input);
    musicToggle?.Invoke();
  }

  public void SoundToggle()
  {
    Print.PrintDebug("Sound toggle button clicked", PrintType.Input);
    soundToggle?.Invoke();
  }
  
}
}
