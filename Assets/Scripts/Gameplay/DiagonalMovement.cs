using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMovement : MonoBehaviour
{
    [SerializeField] private float _minX = -1.7f;
    [SerializeField] private float _maxX = 1.7f;
    [SerializeField] private float _minY = -1.7f;
    [SerializeField] private float _maxY = 1.7f;
    [SerializeField] private float _speed = 2.5f;
    
    private Vector2 _direction = Vector2.one;
    
    void Update()
    {
        DiagMovement();
    }

    private void DiagMovement()
    {
        if (transform.position.x >= _maxX || transform.position.x <= _minX)
        {
            _direction.x *= -1;
        }

        if (transform.position.y >= _maxY || transform.position.y <= _minY)
        {
            _direction.y *= -1;
        }

        transform.position = new Vector2(transform.position.x + _speed * _direction.x * Time.deltaTime,
            transform.position.y + _speed * _direction.y * Time.deltaTime);
    }
}
