using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMediator
{
    void GoalScored();
}

public class GameMediator : MonoBehaviour, IMediator
{
    private Counter counter;

    public GameMediator(Counter counter)
    {
        this.counter = counter;
    }
    public void GoalScored()
    {
        counter.IncreasePoints();
        counter.IncreaseCash();
    }
}
