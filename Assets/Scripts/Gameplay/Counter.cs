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
    private int points = 0;
    private float _positionY;

    private void Awake()
    {
        GoalChecker.OnGoal += IncreasePoints;
    }

    private void Update()
    {
        Vector3 position = pointsText.transform.position;
        
        _positionY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * 0.64f, 0)).y;
        
        position.y = _positionY;
        pointsText.transform.position = position;
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
