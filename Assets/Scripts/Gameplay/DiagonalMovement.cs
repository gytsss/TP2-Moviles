using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DiagonalMovement : MonoBehaviour
{
    #region EXPOSED_FIELDS

    [SerializeField] private float minX = -1.7f;
    [SerializeField] private float maxX = 1.7f;
    [SerializeField] private float minY = -1.7f;
    [SerializeField] private float maxY = 1.7f;
    [SerializeField] private float speed = 2.5f;

    #endregion

    #region PRIVATE_FIELDS

    private Vector2 direction = Vector2.one;

    #endregion

    #region UNITY_CALLS

    private void Update()
    {
        DiagMovement();
    }

    #endregion

    #region PRIVATE_METHODS

    private void DiagMovement()
    {
        if (transform.position.x >= maxX || transform.position.x <= minX)
        {
            direction.x *= -1;
        }

        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            direction.y *= -1;
        }

        transform.position = new Vector2(transform.position.x + speed * direction.x * Time.deltaTime,
            transform.position.y + speed * direction.y * Time.deltaTime);
    }

    #endregion
}