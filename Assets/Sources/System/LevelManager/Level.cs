/* Level.cs

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
  [System.Serializable]
  public class Level
  {
    public LevelType levelType;
    public GameObject levelPrefab;
    public int levelId;
    public bool IsLevelCompleted = false;
    public bool IsLevelFailed = false;
  }
}
