using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private List<Level> _levels;
    
    public Level CurrentLevel { get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _levels = new List<Level>
        {
            new Level { LevelNumber = 1, RimSpeed = 1f, RimMovement = "Static" },
            new Level { LevelNumber = 2, RimSpeed = 1.5f, RimMovement = "Horizontal" },
            new Level { LevelNumber = 3, RimSpeed = 2.5f, RimMovement = "Diagonal" },
        };

        SetCurrentLevel(1);
        Debug.Log("(awake)Current Level: " + CurrentLevel.LevelNumber.ToString());

        Counter.OnNextLevel += NextLevel;
    }
    

    public void NextLevel()
    {
        if (CurrentLevel.LevelNumber < _levels.Count)
        {
            CurrentLevel = _levels[CurrentLevel.LevelNumber];
        }
        Debug.Log("(next level)Current Level: " + CurrentLevel.LevelNumber);
    }
    
    public void SetCurrentLevel(int levelNumber)
    {
        CurrentLevel = _levels[levelNumber - 1];
        Debug.Log("(set current level)Current Level: " + CurrentLevel.LevelNumber);
    }
    
    private void OnDestroy()
    {
        Counter.OnNextLevel -= NextLevel;
    }
}
