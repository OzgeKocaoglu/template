/* PausePanel.cs

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
public class PausePanel: Panel
{
  void On_PauseStateExited()
  {
    hide();
    Print.PrintDebug("Pause panel is deactivated", PrintType.UI);
  }

  void On_PauseStateEntered()
  {
      show();
      Print.PrintDebug("Pause panel is activated", PrintType.UI);
  }

  public override void hide()
  {
    this.gameObject.SetActive(false);
  }

  public override void show()
  {
    this.gameObject.SetActive(true);
  }

  public override void init()
  {
    PauseState.Instance.pauseEnter += On_PauseStateEntered;
    PauseState.Instance.pauseExit += On_PauseStateExited;
  }
}
}
