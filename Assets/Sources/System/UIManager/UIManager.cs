/* UIManager.cs

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

public class UIManager: SingletonManager<UIManager>
{
    private UIManager() { }
    public Canvas canvas;
    public List<Panel> _panels;

    public void init()
    {
      foreach (var panel in _panels) {
          if (panel != null) {
            var _panel = Instantiate(panel, canvas.transform, false);
            _panel.init();
            _panel.hide();
          }
      }
    }
}

}
