using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLimit : MonoBehaviour
{
    [SerializeField] private float _difference = .2f;
    
    private float _boundary;
    void Update()
    {
        Vector3 position = transform.position;
        
         _boundary = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * 0.75f, 0)).y;
        
        position.y = _boundary - _difference;
        transform.position = position;
    }
}
