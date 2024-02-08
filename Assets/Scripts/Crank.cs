using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crank : MonoBehaviour
{
    [SerializeField] private GameObject spikedBallPrefab;
    [SerializeField] private GameObject chainPrefab;

    [SerializeField] private float radius;
    [Range(0f, 360f)]
    [SerializeField] private float angles;
    [Range(0f, 360f)]
    [SerializeField] private float startingAngle;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int segments = 36;

    private bool rotateClockwise = true;
    private GameObject spikedBall;
    private void Start()
    {
        InstantiateSpikedBall();
    }
    private void Update()
    {
        if (spikedBall)
        {
            int rotationDirection = rotateClockwise ? 1 : -1;
            float rotationAmount = rotationSpeed * rotationDirection * Time.deltaTime;
            spikedBall.transform.RotateAround(transform.position, Vector3.forward, rotationAmount);
            if (Mathf.Abs(spikedBall.transform.rotation.eulerAngles.z) >= angles)
            {
                rotateClockwise = !rotateClockwise;
            }
        }
    }
    private void InstantiateSpikedBall()
    {
        float rad = Mathf.Deg2Rad * startingAngle;
        float x = transform.position.x + radius * Mathf.Cos(rad);
        float y = transform.position.y + radius * Mathf.Sin(rad);

        Vector3 newPos = new Vector3(x, y, 0f);
        spikedBall = Instantiate(spikedBallPrefab, newPos, Quaternion.identity, transform);
        InstantiateChains();
    }
    private void InstantiateChains()
    {
        Vector3 startPosition = transform.position;
        Vector3 pivotPosition = spikedBall.transform.position;
        float distance = Vector3.Distance(startPosition, pivotPosition);
        Vector3 direction = (pivotPosition - startPosition).normalized;
        int numberOfInstances = Mathf.FloorToInt(distance / chainPrefab.transform.localScale.y);

        for (int i = 0; i < numberOfInstances; i++)
        {
            Vector3 nextPosition = startPosition + direction * (i + 1) * chainPrefab.transform.localScale.y;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Instantiate(chainPrefab, nextPosition, Quaternion.Euler(0f, 0f, angle + 90f), spikedBall.transform);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 startPoint = transform.position;
        float angleInRadians = (startingAngle + 45f) * Mathf.Deg2Rad;
        Vector3 direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        Vector2 endPoint = startPoint + direction * radius;

        Gizmos.DrawLine(startPoint, endPoint);
        DrawCircleGizmo();
    }
    private void OnDrawGizmosSelected()
    {
        DrawCircleGizmo();
    }
    private void DrawCircleGizmo()
    {
        Gizmos.color = Color.green;

        float angleStep = angles / segments;

        Vector3 prevPoint = Vector3.zero;

        for (float angle = startingAngle; angle <= startingAngle + angles; angle += angleStep)
        {
            float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

            Vector3 currentPoint = new Vector3(x, y, 0);

            if (angle > startingAngle)
            {
                Gizmos.DrawLine(prevPoint + transform.position, currentPoint + transform.position);
            }

            prevPoint = currentPoint;
        }
    }
}
