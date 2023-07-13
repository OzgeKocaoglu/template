/* Panel.cs

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
public class Panel : MonoBehaviour, IPanel
{
  virtual public void hide()
  {
    this.gameObject.SetActive(false);
  } 
  
  virtual public void init()
  {
    this.gameObject.SetActive(false);
  } 

  virtual public void show()
  {
    this.gameObject.SetActive(false);
  }
}
}
