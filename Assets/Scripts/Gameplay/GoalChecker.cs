using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CandyCoded;
using CandyCoded.HapticFeedback;

public class GoalChecker : MonoBehaviour
{

    private IMediator mediator;
    
    public void SetMediator(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Handheld.Vibrate();
            HapticFeedback.HeavyFeedback();
            Debug.Log("Vibration!");
            Debug.Log("Goal!");
            mediator.GoalScored();
        }
    }
}
