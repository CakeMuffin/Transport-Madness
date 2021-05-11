using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingObstacle : MonoBehaviour
{
	[SerializeField] private Transform rayOrigin;
	[SerializeField] private float speed = 0.5f;

	private Rigidbody rb;
	private bool isColided = false;
	private bool isObstructed = false;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		RaycastHit hit;

		if (Physics.Raycast(rayOrigin.position, transform.forward, out hit, 10))
		{
			if (hit.transform.CompareTag("Obstacle") || hit.transform.CompareTag("Player"))
			{
				isObstructed = true;

			}
		}
		else
		{
			isObstructed = false;
		}

		Debug.DrawRay(rayOrigin.position, transform.forward * 10, Color.red);
	}

	private void FixedUpdate()
	{
		if (!isColided && !isObstructed)
		{
			rb.AddRelativeForce(Vector3.forward * speed);
		} 
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			isColided = true;
		}
	}
}
