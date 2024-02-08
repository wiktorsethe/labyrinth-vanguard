using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Rock : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private GameObject obj;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        float distance = Vector3.Distance(obj.transform.position, waypoints[currentWaypointIndex].position);
        float duration = distance / speed;

        obj.transform.DOMove(waypoints[currentWaypointIndex].position, duration)
            .SetEase(Ease.InSine)
            .OnComplete(OnWaypointReached);
    }

    private void OnWaypointReached()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }

        MoveToWaypoint();
    }
}
