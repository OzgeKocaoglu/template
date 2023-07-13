/* SingletonManager.cs

    ----------------------------------------------------------------------
    Persephone

    Author : Özge Kocaoğlu 
* ------------------------------------------------------------------------ */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Persephone;

public class SingletonManager<T>  : MonoBehaviour where T : MonoBehaviour
{
  private static T _instance;
  
  private static object _lock = new object();
  
  public static T Instance
  {
    get {
      if (applicationIsQuitting) {
        Print.PrintDebug("[Singleton] Instance '" + typeof(T) +
            "' already destroyed on application quit." +
            " Won't create again - returning null.", PrintType.SingletonManager);
        return null;
      }  
      lock (_lock) {
        if (_instance == null)
        {
            _instance = (T)FindObjectOfType(typeof(T));  
            if (FindObjectsOfType(typeof(T)).Length > 1)
            {
                Print.PrintDebug("[Singleton] Something went really wrong " +
                    " - there should never be more than 1 singleton!" +
                    " Reopening the scene might fix it.", PrintType.SingletonManager);
                return _instance;
            }  
            if (_instance == null)
            {
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<T>();
                singleton.name = "(singleton) " + typeof(T).ToString();  
                DontDestroyOnLoad(singleton);  
                Print.PrintDebug("[Singleton] An instance of " + typeof(T) +
                    " is needed in the scene, so '" + singleton +
                    "' was created with DontDestroyOnLoad.", PrintType.SingletonManager);  
            }
            else
            {
                Print.PrintDebug("[Singleton] Using instance already created: " +
                    _instance.gameObject.name, PrintType.SingletonManager);
            }
        }  
        return _instance;
      }
    }
  }
  
  private static bool applicationIsQuitting = false;
  /// <summary>
  /// When Unity quits, it destroys objects in a random order.
  /// In principle, a Singleton is only destroyed when application quits.
  /// If any script calls Instance after it have been destroyed, 
  ///   it will create a buggy ghost object that will stay on the Editor scene
  ///   even after stopping playing the Application. Really bad!
  /// So, this was made to be sure we're not creating that buggy ghost object.
  /// </summary>
  public void OnDestroy()
  {
    applicationIsQuitting = true;
  }
}
