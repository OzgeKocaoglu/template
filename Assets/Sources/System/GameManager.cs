/* GameManager.cs

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
public class GameManager : MonoBehaviour
{
  StateMachine _stateMachine;
  
  [SerializeField]
  UIManager _uIManager;
  
  [SerializeField]
  LevelManager _levelManager;
  
  [SerializeField]
  AudioManager _audioManager;
  
  [SerializeField]
  PlayerPrefsManager _playerPrefsManager;
  
  [SerializeField]
  ObjectManager _objectManager;

  public GameManager()
  {
    _stateMachine = new StateMachine();
  }
  
  void Awake()
  {
    _playerPrefsManager.AwakePlayerPrefsManager();
    _uIManager.init();
    _audioManager.AwakeOmegaAudioManager();
    _levelManager.awake();
    AddListeners();
  }

  void Start()
  {
    Print.PrintDebug("Starting", PrintType.GameManager);
    _stateMachine.SetState(MainMenuState.Instance);
    _audioManager.StartOmegaAudioManager();
    _objectManager.init();
  }

  void Update()
  {
    _stateMachine.UpdateState();
  }

  void AddListeners()
  {
    UIInputManager.playButton += play;
    UIInputManager.pauseButton += pause;
    UIInputManager.resumeButton += play;
    UIInputManager.homeButton += home;
    UIInputManager.retryButton += retry;
    UIInputManager.nextLevelButton += nextLevel;
    UIInputManager.preLevelButton += preLevel;
    UIInputManager.restartLevelButton += play;
  }

  void retry()
  {
    Print.PrintDebug("Retry level setted", PrintType.GameManager);
    _stateMachine.SetState(RetryState.Instance);
  }
  
  void preLevel()
  {
    Print.PrintDebug("Pre level setted", PrintType.GameManager);
    _stateMachine.SetState(MainMenuState.Instance);
    LevelManager.Instance.restartLevel();
  }
  
  void pause()
  {
    Print.PrintDebug("Game is paused", PrintType.GameManager);
    _stateMachine.SetState(PauseState.Instance);
  }

  void play()
  {
    Print.PrintDebug("Game is starting", PrintType.GameManager);
    _stateMachine.SetState(GamePlayState.Instance);
    _stateMachine.EnterState();
  }

  void home()
  {
    Print.PrintDebug("Going back to home page!", PrintType.GameManager);
    LevelManager.Instance.restartLevel();
    _stateMachine.SetState(MainMenuState.Instance);
  }

  void nextLevel()
  {
    Print.PrintDebug("Game is starting", PrintType.GameManager);
    _stateMachine.SetState(MainMenuState.Instance);
  }
}

}
