using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Counter counter;
    [SerializeField] private TextMeshProUGUI shootsText;
    [SerializeField] private int maxShoots = 0;

    private int shoots = 0;

    private void Awake()
    {
        tutorialPanel.SetActive(true);
        losePanel.SetActive(false);
    }

    private void Update()
    {
        if (shoots < maxShoots && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchedPos =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y,
                    5));

            float boundary = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * 0.75f, 0)).y;

            if (touchedPos.y > boundary)
            {
                int count = 0;
                if (count == 0)
                {
                    tutorialPanel.SetActive(false);
                    count++;
                }

                shoots++;
                UpdateText();

                GameObject ball = Instantiate(ballPrefab, touchedPos, Quaternion.identity) as GameObject;
                //ball.GetComponent<SpriteRenderer>().sprite = ShopManager.Instance.GetActiveBallSprite();

                Destroy(ball, 3f);
            }

            StartCoroutine(CheckLoseCoroutine());
        }
    }


    private IEnumerator CheckLoseCoroutine()
    {
        int remainingPoints = counter.GetWinPoints() - counter.GetPoints();
        int remainingShoots = maxShoots - shoots;

        if (remainingShoots < remainingPoints - 1)
        {
            Handheld.Vibrate();
            Debug.Log("Lose!");
            losePanel.SetActive(true);

            yield return new WaitForSeconds(3);

            StartCoroutine(LoadSceneAsync("Menu"));
        }
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void UpdateText()
    {
        shootsText.text = (maxShoots - shoots).ToString();
    }
}