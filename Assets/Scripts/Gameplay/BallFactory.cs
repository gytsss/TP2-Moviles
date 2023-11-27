using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBall
{
    GameObject CreateBall();
}

public class BallFactory : MonoBehaviour
{
    #region PRIVATE_FIELDS

    private GameObject ballPrefab;

    #endregion

    #region PUBLIC_METHODS
    public BallFactory(GameObject ballPrefab)
    {
        this.ballPrefab = ballPrefab;
    }

    public GameObject CreateBall()
    {
        GameObject ball = GameObject.Instantiate(ballPrefab);
        ball.SetActive(false);
        return ball;
    }
    #endregion
}