using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private float speed;

	private Vector3 targetPosition;
	[SerializeField] Transform target;

	private float distance;

	[SerializeField] float startLimit = 2f;
	[SerializeField] float maxDistanceBeforeLose = 7f;
	[SerializeField] private float smoothSpeed = 1f;
	private Player player;

	void Start()
	{
		player = GameObject.FindObjectOfType(typeof(Player)) as Player;
	}
	void LateUpdate()
	{
		distance = target.position.y - transform.position.y;

		if (target.position.y < startLimit)
			return;

		if (distance < -maxDistanceBeforeLose)
		{
			player.Die();
			Time.timeScale = 1f;
		}
		else if (distance > 1)
		{
			targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetPosition, distance * Time.deltaTime);
		}
		else
		{
			targetPosition = new Vector3(target.position.x, transform.position.y + speed, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
		}
	}
}
