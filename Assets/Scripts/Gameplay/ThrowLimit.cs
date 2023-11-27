using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLimit : MonoBehaviour
{
    #region EXPOSED_FIELDS

    [SerializeField] private float _difference = .2f;

    #endregion

    #region PRIVATE_FIELDS

    private float _boundary;

    #endregion

    #region UNITY_CALLS

    private void Update()
    {
        Vector3 position = transform.position;

        _boundary = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * 0.75f, 0)).y;

        position.y = _boundary - _difference;
        transform.position = position;
    }

    #endregion
}