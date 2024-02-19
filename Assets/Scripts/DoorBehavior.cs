using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool _isDoorOpen = false;
    public Vector3 _offset;
    Vector3 _doorClosePos;
    Vector3 _doorOpenPos;
    float _doorSpeed = 10f;

    void Awake()
    {
        _doorClosePos = transform.position;
        _doorOpenPos = transform.position + _offset;
    }

    void Update()
    {
        if (_isDoorOpen)
        {
            MoveTo(_doorOpenPos);
        }
        else if (!_isDoorOpen)
        {
            MoveTo(_doorClosePos);
        }
    }

    void MoveTo(Vector3 target)
    {
        if (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                target, _doorSpeed * Time.deltaTime);
        }
    }
}