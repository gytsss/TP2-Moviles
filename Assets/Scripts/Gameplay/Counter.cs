using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public static event Action OnNextLevel;
    
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private Menu sceneManager;
    [SerializeField] private int winPoints = 0;
    [SerializeField] private int thisLevel = 0;
    private int points = 0;
    private int currentLevel = 0;
    private float positionY;

    private void Awake()
    {
        GoalChecker.OnGoal += IncreasePoints;
        currentLevel = thisLevel;
        UpdateText();
    }

    private void Update()
    {
        Vector3 position = pointsText.transform.position;
        
        positionY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * 0.64f, 0)).y;
        
        position.y = positionY;
        pointsText.transform.position = position;
        
        CheckWin();
    }

    public void IncreasePoints()
    {
        points++;
        UpdateText();
    }

    private void UpdateText()
    {
        pointsText.text = points.ToString() + "/" + winPoints.ToString();
    }

    private void CheckWin()
    {
        if (points >= winPoints)
        {
            sceneManager.PlayLevel(currentLevel + 1);
        }
    }

    private void OnDestroy()
    {
        GoalChecker.OnGoal -= IncreasePoints;
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }
}
