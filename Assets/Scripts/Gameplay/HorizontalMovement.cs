using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HorizontalMovement : MonoBehaviour
{
    #region EXPOSED_FIELDS

    [SerializeField] private float minX = -1.7f;
    [SerializeField] private float maxX = 1.7f;
    [SerializeField] private float speed = 1.5f;

    #endregion

    #region PRIVATE_FIELDS

    private Vector2 direction = Vector2.one;

    #endregion

    #region UNITY_CALLS

    private void Update()
    {
        HorMovement();
    }

    #endregion

    #region PRIVATE_METHODS

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

    #endregion
}