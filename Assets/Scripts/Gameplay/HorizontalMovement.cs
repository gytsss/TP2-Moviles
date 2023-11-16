using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float _minX = -1.7f;
    [SerializeField] private float _maxX = 1.7f;
    [SerializeField] private float _speed = 1.5f;
    
    private Vector2 _direction = Vector2.one;

    void Update()
    {
        HorMovement();
    }
    
    private void HorMovement()
    {
        if (transform.position.x >= _maxX)
        {
            _direction.x = -1;
        }
        else if (transform.position.x <= _minX)
        {
            _direction.x = 1;
        }

        transform.position = new Vector2(transform.position.x + _speed * _direction.x * Time.deltaTime,
            transform.position.y);
    }
}
