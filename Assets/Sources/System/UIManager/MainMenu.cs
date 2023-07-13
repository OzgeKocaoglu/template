/* MainMenu.cs

    ----------------------------------------------------------------------
    Persephone

    Author : Özge Kocaoğlu 
* ------------------------------------------------------------------------ */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Persephone
{
public class CasualMainMenu: Panel
{
    public Text dinamicLevelText;

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
      MainMenuState.Instance.mainMenuEnter += enter;
      MainMenuState.Instance.mainMenuExit += exit;
    }

    void exit()
    {
      Print.PrintDebug("Main Menu panel is deactivated", PrintType.UI);
      hide();
    }

    void enter()
    {
      Print.PrintDebug("Main Menu panel is activated", PrintType.UI);
      show();
    }
}
}
