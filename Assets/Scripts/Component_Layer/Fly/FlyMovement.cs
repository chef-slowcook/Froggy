using System;
using System.Collections;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    [Header("Flight Variables")]
    [SerializeField, Range(0f, 10f)] private float speed = 1;
    [SerializeField, Range(0.1f, 5f)] float flutterRadius = 2f;
    private Transform currentPivot;
    private bool isMoving = false;

    public void StartMoving(Transform pivot)
    {
        isMoving = true;
        currentPivot = pivot;
        StartCoroutine(Flutter());
    }

    private IEnumerator Flutter()
    {
        //Distance away from pivot
        float distance = 0;
        //The position where the fly is going to move to
        Vector3 target = Vector3.zero;
        while (isMoving)
        {
            RandomizeTarget(ref target, currentPivot.position);
            distance = Vector3.Distance(transform.position, target);
            //Get close to object
            while (distance > 0.1f)
            {
                float realSpeed = Time.deltaTime * speed;
                transform.position = Vector3.MoveTowards(transform.position, target, realSpeed);
                distance = Vector3.Distance(transform.position, target);
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
