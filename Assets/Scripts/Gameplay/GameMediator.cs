using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMediator
{
    void GoalScored();
}

public class GameMediator : MonoBehaviour, IMediator
{
    #region PRIVATE_FIELDS

    private Counter counter;

    #endregion

    #region PUBLIC

    public GameMediator(Counter counter)
    {
        this.counter = counter;
    }

    public void GoalScored()
    {
        counter.IncreasePoints();
        counter.IncreaseCash();
    }

    #endregion
}