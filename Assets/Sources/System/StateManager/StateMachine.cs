/* StateMachine.cs

    ----------------------------------------------------------------------
    Persephone

    Author : Özge Kocaoğlu 
* ------------------------------------------------------------------------ */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Persephone {

/// <summary>
/// This state machine controls state changes. 
/// </summary>
public class StateMachine
{
  public State _previousState;
  public State _currentState;
  private List<State> _states;
  
  public StateMachine(params State[] states)
  {
    _states = new List<State>();
    InitiliazeStates(states);
  }
  
  public void SetState(State newState)
  {
    if (_currentState != null) _currentState.Exit();
      _previousState = _currentState;
    
    _currentState = newState;
    _currentState.Enter();
  }
  
  public void EnterState()
  {
    if (_currentState != null) _currentState.Enter();
  }

  public void UpdateState()
  {
    if (_currentState != null) _currentState.Execute();
  }

  public void ExitState()
  {
    if (_currentState != null) _currentState.Exit();
      _currentState = _previousState;
  }
  
  void InitiliazeStates(params State[] states)
  {
    _states.AddRange(states.Where(x => x != null));
  }

}

}