using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CandyCoded;
using CandyCoded.HapticFeedback;

public class GoalChecker : MonoBehaviour
{
    public static event Action OnGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Handheld.Vibrate();
            HapticFeedback.HeavyFeedback();
            Debug.Log("Vibration!");
            Debug.Log("Goal!");
            OnGoal?.Invoke();
        }
    }
}
