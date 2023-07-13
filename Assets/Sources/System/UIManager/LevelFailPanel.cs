/* LevelFailPanel.cs

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
public class LevelFailPanel: Panel
{
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
  }

  void exit()
  {
    Print.PrintDebug("Level failed panel is deactivated", PrintType.UI);
    hide();
  }

  void enter()
  {
    Print.PrintDebug("Level failed panel is activated", PrintType.UI);
    show();
  }
}
}
