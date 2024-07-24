using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    
    public void Move(List<Vector3> points)
    {
        StartCoroutine(MoveRope(points));
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
