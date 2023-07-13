/* SettingState.cs

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
class SettingState : State
{
  public GameState settingsEnter;
  public GameState settingsExecute;
  public GameState settingsExit;
  
  public static SettingState Instance;
  
  public SettingState()
  {
    if (Instance == null) Instance = this;
  }

  public override void Enter()
  {
    Print.PrintDebug("SettingsState entered", PrintType.State);
    settingsEnter?.Invoke();
  }
  public override void Execute()
  {
    Print.PrintDebug("SettingState execute", PrintType.State);
    settingsExecute?.Invoke();
  }
  
  public override void Exit()
  {
    Print.PrintDebug("SettingState exited", PrintType.State);
    settingsExit?.Invoke();
  }

}
}
