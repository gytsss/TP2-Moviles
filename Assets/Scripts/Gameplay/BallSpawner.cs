using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    public int maxShoots = 0;
    public int shoots = 0;

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
                shoots++;
                GameObject ball = Instantiate(ballPrefab, touchedPos, Quaternion.identity) as GameObject;
                ball.GetComponent<SpriteRenderer>().sprite = ShopManager.Instance.GetActiveBallSprite();

                Destroy(ball, 3f);
            }
        }
    }
}