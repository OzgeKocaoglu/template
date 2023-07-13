/* Print.cs

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
  public enum PrintType
  {
    UI,
    Input,
    State,
    GameManager,
    SingletonManager,
    AudioManager,
    HapticManager
  }
  
  public static class Print
  {
  
    public static void PrintDebug(string debugMessage, PrintType type) 
    {
      switch(type) {
        case PrintType.UI:
          Debug.Log("<b>Persephone:</b>\n <color=#008080ff>UI Log: </color> " + debugMessage);
        break;
        case PrintType.Input:
          Debug.Log("<b>Persephone:</b>\n <color=#ff00ffff>Input Log: </color> " + debugMessage);
        break;
        case PrintType.State:
          Debug.Log("<b>Persephone:</b>\n <color=#800000ff>Game State Log: </color> " + debugMessage);
        break;
        case PrintType.GameManager:
          Debug.Log("<b>Persephone:</b>\n <color=#00ff00ff>Game Manager Log: </color> " + debugMessage);
        break;
        case PrintType.SingletonManager:
          Debug.Log("<b>Persephone:</b>\n <color=#00ffffff>Singleton Manager Log: </color> " + debugMessage);
        break;
        case PrintType.AudioManager:
          Debug.Log("<b>Persephone:</b>\n <color=#808000ff>AudioManager Manager Log: </color> " + debugMessage);
        break;
        case PrintType.HapticManager:
          Debug.Log("<b>Persephone:</b>\n <color=#ffa500ff>HapticManager Manager Log: </color> " + debugMessage);
        break;
      }
      
    } 
  }
}