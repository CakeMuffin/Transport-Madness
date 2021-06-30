using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingObstacle : MonoBehaviour
{
	[SerializeField] private float speed = 0.5f;

	private Rigidbody rb;
	private bool isColided = false;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		rb.AddRelativeForce(Vector3.forward * 15, ForceMode.VelocityChange);
	}

	void Update()
	{

	}

	private void FixedUpdate()
	{
		if (!isColided)
		{
			rb.AddRelativeForce(Vector3.forward * speed);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Car"))
		{
			isColided = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			rb.freezeRotation = false;
		}
	}
}
