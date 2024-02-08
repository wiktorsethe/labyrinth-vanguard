using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    private int currentWaypointIndex = 0;
    [SerializeField] private GameObject obj;
    private void Update()
    {
        MoveToWaypoint();
    }
    private void MoveToWaypoint()
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
        if (Vector3.Distance(obj.transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}
