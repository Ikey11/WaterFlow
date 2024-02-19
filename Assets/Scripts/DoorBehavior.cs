using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool _isDoorOpen = false;
    public float _offset = 3f;
    Vector3 _doorClosePos;
    Vector3 _doorOpenPos;
    float _doorSpeed = 10f;

    void Awake()
    {
        _doorClosePos = transform.position;
        _doorOpenPos = new Vector3(transform.position.x, 
            transform.position.y + _offset, transform.position.z);
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