/* GamePlayState.cs

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
public class GamePlayState : State
{
  public GameState gameplayEnter;
  public GameState gameplayExit;
  public GameState gameplayExecute;

  public static GamePlayState Instance;
  bool isLevelStarted = false;

  public GamePlayState()
  {
    if(Instance == null) Instance = this;
      LevelManager.levelStart += levelStarted;
  
  }

  void levelStarted()
  {
    isLevelStarted = true;
  }

  public override void Enter()
  {
    Print.PrintDebug("Gameplay state Entered", PrintType.State);
    gameplayEnter?.Invoke();
    Time.timeScale = 1f;
  }


  public override void Execute()
  {
    if (isLevelStarted) {
      Enter();
      isLevelStarted = false;
    }

    gameplayExecute?.Invoke();
  }

  public override void Exit() {
    Print.PrintDebug("Gameplay state Exited", PrintType.State);
    gameplayExit?.Invoke();
  }
}
}