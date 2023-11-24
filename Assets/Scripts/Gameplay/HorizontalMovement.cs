using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float minX = -1.7f;
    [SerializeField] private float maxX = 1.7f;
    [SerializeField] private float speed = 1.5f;
    
    private Vector2 direction = Vector2.one;

    void Update()
    {
        HorMovement();
    }
    
    private void HorMovement()
    {
        if (transform.position.x >= maxX)
        {
            direction.x = -1;
        }
        else if (transform.position.x <= minX)
        {
            direction.x = 1;
        }

        transform.position = new Vector2(transform.position.x + speed * direction.x * Time.deltaTime,
            transform.position.y);
    }
}
