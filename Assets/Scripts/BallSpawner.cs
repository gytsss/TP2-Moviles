using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchedPos =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y,
                    10));

            GameObject ball = Instantiate(ballPrefab, touchedPos, Quaternion.identity) as GameObject;

            Destroy(ball, 2f);
        }
    }
}