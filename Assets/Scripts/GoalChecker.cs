using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
    public static event Action OnGoal;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Debug.Log("Goal!");
            OnGoal?.Invoke();
        }
    }
}
