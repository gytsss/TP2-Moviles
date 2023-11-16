using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RimMovement : MonoBehaviour
{
    [SerializeField] private float _minX = -1.7f;
    [SerializeField] private float _maxX = 1.7f;
    [SerializeField] private float _minY = -1.7f;
    [SerializeField] private float _maxY = 1.7f;
    
    private float _speed;
    private LevelManager _levelManager;
    private Vector2 _direction = Vector2.one;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        
        _speed = _levelManager.CurrentLevel.RimSpeed;
    }

    private void Update()
    {
        _speed = _levelManager.CurrentLevel.RimSpeed;
        
        Debug.Log("Current rim movement: " + _levelManager.CurrentLevel.RimMovement);
        
        switch (_levelManager.CurrentLevel.RimMovement)
        {
            case "Static":
                break;
            case "Horizontal":
                HorizontalMovement();
                break;
            case "Diagonal":
                DiagonalMovement();
                break;
        }
    }

    private void HorizontalMovement()
    {
        if (transform.position.x >= _maxX)
        {
            _direction.x = -1;
        }
        else if (transform.position.x <= _minX)
        {
            _direction.x = 1;
        }

        transform.position = new Vector2(transform.position.x + _speed * _direction.x * Time.deltaTime, transform.position.y);
    }
    
    private void DiagonalMovement()
    {
        if (transform.position.x >= _maxX || transform.position.x <= _minX)
        {
            _direction.x *= -1;
        }
        if (transform.position.y >= _maxY || transform.position.y <= _minY)
        {
            _direction.y *= -1;
        }

        transform.position = new Vector2(transform.position.x + _speed * _direction.x * Time.deltaTime, transform.position.y + _speed * _direction.y * Time.deltaTime);
    }
    
}
