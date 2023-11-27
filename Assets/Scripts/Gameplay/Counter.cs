using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Menu sceneManager;
    [SerializeField] private int winPoints = 0;
    [SerializeField] private int thisLevel = 0;
    private int points = 0;
    private int currentLevel = 0;
    private float positionY;
    private int cash = 0;

    private void Awake()
    {
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
            
            if (currentLevel < 3)
            {
                StartCoroutine(LoadSceneAsync("Level" + (currentLevel + 1)));
            }
            else
            {
                winPanel.SetActive(true);
                StartCoroutine(LoadSceneAsync("Menu"));
            }
        }
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return new WaitForSeconds(4f);
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public int GetCash()
    {
        return cash;
    }

    public void IncreaseCash()
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

    public int GetWinPoints()
    {
        return winPoints;
    }

    public int GetPoints()
    {
        return points;
    }
}