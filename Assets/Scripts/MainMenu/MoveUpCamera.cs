using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCamera : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _targetPos;
    private Vector3 _currentDirection;
    private Transform _thisTransform;



    private void Start()
    {
        _currentDirection = Vector3.up;
        _thisTransform = transform;
    }

    private void Update()
    {
        _thisTransform.Translate(_currentDirection * _speed * Time.deltaTime);

        if (transform.position.z >= 17)
        {
            gameObject.transform.position = _targetPos;
        }
    }
}
