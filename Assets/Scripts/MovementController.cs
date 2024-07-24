using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public event Action<Vector3> ShowEndUI;
    
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Collider _finishPoint;

    private Coroutine _coroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _finishPoint) 
        {
            StopCoroutine(_coroutine);
            ShowEndUI!.Invoke(_finishPoint.transform.position);
        }
    }
    
    public void Move(List<Vector3> points)
    {
        _coroutine = StartCoroutine(MoveRope(points));
    }

    private IEnumerator MoveRope(List<Vector3> points)
    {
        foreach (var point in points)
        {
            var startPosition = transform.position;

            var currentTime = 0f;

            while (currentTime < _movementSpeed)
            {
                transform.position = Vector3.Lerp(startPosition, point, currentTime / _movementSpeed);
                currentTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
