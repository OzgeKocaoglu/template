/* RetryPanel.cs

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
class RetryPanel: Panel
{
  public override void init()
  {
    RetryState.Instance.retryEnter += enter;
    RetryState.Instance.retryExit += exit;
  }  
  
  public override void hide()
  {
    this.gameObject.SetActive(false);
  }  

  public override void show()
  {
    this.gameObject.SetActive(true);
  }

  void exit()
  {
    hide();
    Print.PrintDebug("Retry panel is deactivated", PrintType.UI);
  }

  void enter()
  {
    show();
    Print.PrintDebug("Retry panel is activated", PrintType.UI);
  }  
}
}
