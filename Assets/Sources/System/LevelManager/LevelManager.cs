/* LevelManager.cs

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
public enum LevelType
{
    Normal, 
    Bonus, 
    Tutorial
}

public class LevelManager : SingletonManager<LevelManager>
{ 
  LevelManager() { }
  public Level currentLevel;
  public GameObject currentLevelObject;
  public List<Level> levels;
  public delegate void GameLevel();
  public static GameLevel levelComplete;
  public static GameLevel levelStart;
  public static GameLevel levelFail;

  public void awake()
  {
    UIInputManager.nextLevelButton += setNextLevel;
    UIInputManager.preLevelButton += setPreLevel;
    UIInputManager.resetLevelButton += resetLevels;
    UIInputManager.restartLevelButton += restartLevel;

    if (PlayerPrefs.GetInt("level") == 0) PlayerPrefs.SetInt("level", 1);

    init(PlayerPrefs.GetInt("level"));
    currentLevel = levels[PlayerPrefs.GetInt("level")-1];
  }

  public void setPreLevel()
  {
    if (currentLevel.levelId == 1) {
      destoryLevel(currentLevelObject);
      levelStart?.Invoke();
      currentLevel = find(levels[levels.Count-1].levelId);
      init(currentLevel.levelId);
    }
    else {
      destoryLevel(currentLevelObject);
      levelStart?.Invoke();
      currentLevel = find(currentLevel.levelId - 1);
      init(currentLevel.levelId);
    }
  }

  public void restartLevel()
  {
    destoryLevel(currentLevelObject);
    levelStart?.Invoke();
    init(currentLevel.levelId);
  }

  public void setNextLevel()
  {
    if (currentLevel.levelId == levels.Count) {
      destoryLevel(currentLevelObject);
      levelStart?.Invoke();
      currentLevel = find(1);
      init(1);
    }
    else {
      destoryLevel(currentLevelObject);
      levelStart?.Invoke();
      currentLevel = find(currentLevel.levelId + 1);
      init(currentLevel.levelId);
    }
  }

  public void resetLevels()
  {
    destoryLevel(currentLevelObject);
    currentLevel = levels[0];
    levelStart?.Invoke();
    init(currentLevel.levelId);
  }

  public void fail()
  {
    if (!currentLevel.IsLevelFailed) {
      currentLevel.IsLevelFailed = true;
      levelFail?.Invoke();
    }
  }

  public void success()
  {
    if (!currentLevel.IsLevelCompleted) {
      currentLevel.IsLevelCompleted = true;
      levelComplete?.Invoke();
    }
  }

  Level find(int levelId)
  {
    return levels.ElementAt(levelId-1);
  }

  void destoryLevel(GameObject gameObject)
  {
    Destroy(gameObject);
  }

  void init(int levelId)
  {
    find(levelId).IsLevelCompleted = false;
    find(levelId).IsLevelFailed = false;
    currentLevelObject = Instantiate(find(levelId).levelPrefab);
    PlayerPrefs.SetInt("level", levelId);
    currentLevelObject.SetActive(true);
  }

}
}
