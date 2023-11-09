using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    private int points = 0;

    private void Awake()
    {
        GoalChecker.OnGoal += IncreasePoints;
    }
    public void IncreasePoints()
    {
        points++;
        UpdateText();
    }

    private void UpdateText()
    {
        pointsText.text = points.ToString();
    }

    private void OnDestroy()
    {
        GoalChecker.OnGoal -= IncreasePoints;
    }
}
