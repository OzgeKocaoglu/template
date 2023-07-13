/* State.cs

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

public abstract class State
{
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();

    public delegate void GameState();
}

}