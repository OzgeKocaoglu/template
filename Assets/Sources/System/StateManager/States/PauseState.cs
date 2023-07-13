/* PauseState.cs

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
class PauseState : State
{
  public GameState pauseEnter;
  public GameState pauseExit;
  public GameState pauseExecute;
  
  public static PauseState Instance;
  public PauseState()
  {
    if (Instance == null) Instance = this;
  }

  public override void Enter()
  {
    Print.PrintDebug("PauseState entered", PrintType.State);
    pauseEnter?.Invoke();
    Time.timeScale = 0.0f;
  }

  public override void Execute()
  {
    pauseExecute?.Invoke();
  }

  public override void Exit()
  {
    Print.PrintDebug("PauseState exited", PrintType.State);
    pauseExit?.Invoke();
  }
}
}
