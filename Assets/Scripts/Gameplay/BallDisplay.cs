using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDisplay : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private Transform firstPosition;
    
    private float spaceBetweenBalls;
    private GameObject[] balls;

    private void Start()
    {
        balls = new GameObject[ballSpawner.maxShoots];

        for (int i = 0; i < ballSpawner.maxShoots; i++)
        {
            float scale = Mathf.Min(Screen.width, Screen.height) / (ballSpawner.maxShoots * 150f); 
            spaceBetweenBalls = ballPrefab.GetComponent<RectTransform>().rect.width * scale;

            Vector3 position = firstPosition.position + new Vector3(i * spaceBetweenBalls, -80, 0);
            balls[i] = Instantiate(ballPrefab, position, Quaternion.identity, firstPosition.parent);
            balls[i].GetComponent<RectTransform>().anchoredPosition = position;
            balls[i].transform.localScale = new Vector3(scale, scale, 1);
        }
    }

    private void Update()
    {
        for (int i = balls.Length - 1; i >= 0; i--)
        {
            if (i >= ballSpawner.maxShoots - ballSpawner.shoots)
                balls[i].SetActive(false);

            else
                balls[i].SetActive(true);
        }
    }
}