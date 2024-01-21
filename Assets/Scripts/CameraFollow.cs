using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private float speed;

	private Vector3 targetPosition;
	public Transform target;

	private float distance;

	public float startLimit = 2f;
	public float maxDistanceBeforeLose = 7f;

	//private PlayerLife PlayerLife;

	void Start()
	{
		//PlayerLife = GameObject.FindObjectOfType(typeof(PlayerLife)) as PlayerLife;
	}
	void LateUpdate()
	{
		distance = target.position.y - transform.position.y;

		if (target.position.y < startLimit)
			return;

		if (distance < -maxDistanceBeforeLose)
		{
			//PlayerLife.Die();
			Time.timeScale = 1f;
		}
		else if (distance > 1)
		{
			targetPosition = new Vector3(0, target.position.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetPosition, distance * Time.deltaTime);
		}
		else
		{
			targetPosition = new Vector3(0, transform.position.y + speed, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
		}

	}
}
