using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float speed = 1;
    [SerializeField, Range(0.1f, 5f)] float flutterRadius = 2f;
    private bool isMoving = false;
    private Transform currentPivot;

    public void StartMoving(Transform pivot)
    {
        currentPivot = pivot;
        isMoving = true;
        StartCoroutine(Flutter());
    }

    private IEnumerator Flutter()
    {
        float distance = 0;
        Vector3 target = Vector3.zero;
        while (isMoving)
        {
            RandomizeTarget(ref target, currentPivot.position);
            distance = Vector3.Distance(transform.position, target);
            while (distance > 0.1f)
            {
                distance = Vector3.Distance(transform.position, target);
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
                yield return null;
            }
        }
    }

    private void RandomizeTarget(ref Vector3 target, Vector3 pivot)
    {
        Vector2 randomPoint = UnityEngine.Random.insideUnitCircle * flutterRadius;
        target.x = pivot.x + randomPoint.x;
        target.y = pivot.y + randomPoint.y;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
