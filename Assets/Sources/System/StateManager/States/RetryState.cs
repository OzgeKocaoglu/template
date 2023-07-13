/* RetryState.cs

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
public class RetryState : State
{
  public GameState retryEnter;
  public GameState retryExit;
  public GameState retryExecute;

  public static RetryState Instance;

  public RetryState()
  {
    if (Instance == null) Instance = this;
  }

  public override void Enter()
  {
    Print.PrintDebug("RetryState entered", PrintType.State);
    retryEnter?.Invoke();
    Time.timeScale = 0.0f;
  }

  public override void Execute()
  {
    retryExecute?.Invoke();
  }

  public override void Exit()
  {
    Print.PrintDebug("RetryState exited", PrintType.State);
    retryExit?.Invoke();
  }
}
}
