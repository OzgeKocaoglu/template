/* GameplayPanel.cs

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
public class GamePlayPanel : Panel
{
  private void exit()
  {
    Print.PrintDebug("Gameplay panel is deactivated", PrintType.UI);
    hide();
  }

  private void enter()
  {
    Print.PrintDebug("Gameplay panel is activated", PrintType.UI);
    show();
  }
  public override void show()
  {
    this.gameObject.SetActive(true);
  }  
  public override void hide()
  {
    this.gameObject.SetActive(false);
  }  

  public override void init()
  {
    GamePlayState.Instance.gameplayEnter += enter;
    GamePlayState.Instance.gameplayExit += exit;
  }
}
}
