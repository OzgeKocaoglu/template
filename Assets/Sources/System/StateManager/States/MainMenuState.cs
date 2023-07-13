/* MainMenuState.cs

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
class MainMenuState : State
{
  public GameState mainMenuEnter;
  public GameState mainMenuExit;
  public GameState mainMenuExecute;

  public static MainMenuState Instance;
  public MainMenuState()
  {
    if (Instance == null) Instance = this;
  }

  public override void Enter()
  {
    Print.PrintDebug("MainMenuState entered", PrintType.State);
    mainMenuEnter?.Invoke();
    Time.timeScale = 1f;
  }

  public override void Execute()
  {
    mainMenuExecute?.Invoke();
  }

  public override void Exit()
  {
    Print.PrintDebug("MainMenuState exited", PrintType.State);
    mainMenuExit?.Invoke();
  }
}
}
