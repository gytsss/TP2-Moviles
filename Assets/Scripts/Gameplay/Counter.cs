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
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private Menu sceneManager;
    [SerializeField] private int winPoints = 0;
    [SerializeField] private int thisLevel = 0;
    private int points = 0;
    private int currentLevel = 0;
    private float positionY;
    private int cash = 0;

    private void Awake()
    {
        GoalChecker.OnGoal += IncreasePoints;
        GoalChecker.OnGoal += IncreaseCash;
        currentLevel = thisLevel;
        
        cash = PlayerPrefs.GetInt("Cash", 0);
        
        UpdateCashText();
        UpdatePointsText();
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
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        pointsText.text = points.ToString() + "/" + winPoints.ToString();
    }
    private void UpdateCashText()
    {
        cashText.text = cash.ToString();
    }

    private void CheckWin()
    {
        if (points >= winPoints)
        {
            PlayerPrefs.SetInt("Cash", cash);
            Handheld.Vibrate();
            sceneManager.PlayLevel(currentLevel + 1);
        }
    }

    private void OnDestroy()
    {
        GoalChecker.OnGoal -= IncreasePoints;
        GoalChecker.OnGoal -= IncreaseCash;
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public int GetCash()
    {
        return cash;
    }
    private void IncreaseCash()
    {
        cash++;
        UpdateCashText();
        
    }
    public void DecreaseCash(int cash)
    {
        this.cash -= cash;
        UpdateCashText();
        
        PlayerPrefs.SetInt("Cash", cash);
    }
}
