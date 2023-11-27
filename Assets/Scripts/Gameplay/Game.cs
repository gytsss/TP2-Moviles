using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GoalChecker goalChecker;
    [SerializeField] private Counter counter;

    private void Start()
    {
        IMediator mediator = new GameMediator(counter);
        goalChecker.SetMediator(mediator);
    }
}
