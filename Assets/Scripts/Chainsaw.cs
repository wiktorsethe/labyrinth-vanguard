using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 5f;
    private int currentWaypointIndex = 0;
    [SerializeField] private GameObject obj;
    [SerializeField] private float rotatingLocalSpeed;
    private void Update()
    {
        MoveToWaypoint();
        float currentRotation = obj.transform.rotation.eulerAngles.z;
        float newRotation = currentRotation + (rotatingLocalSpeed * Time.deltaTime);
        obj.transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
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
