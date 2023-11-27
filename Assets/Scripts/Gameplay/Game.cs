using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    #region EXPOSED_FIELDS

    [SerializeField] private GoalChecker goalChecker;
    [SerializeField] private Counter counter;

    #endregion

    #region UNITY_CALLS

    private void Start()
    {
        IMediator mediator = new GameMediator(counter);
        goalChecker.SetMediator(mediator);
    }

    #endregion
}