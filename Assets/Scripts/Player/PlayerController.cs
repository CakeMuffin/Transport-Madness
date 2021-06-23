using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float motorTorque;
	[SerializeField] private float maxSteerAngle;
	[SerializeField] private WheelCollider fLWheelCollider;
	[SerializeField] private WheelCollider fRWheelCollider;
	[SerializeField] private WheelCollider rLWheelCollider;
	[SerializeField] private WheelCollider rRWheelCollider;

	private Player player;
	private Rigidbody rb;

	private float verticalInput;
	private float horizontalInput;
	private bool isBreaking = false;
	private float currentSteerAngle;
	private float currentBreakForce;
	private float speed;

	public float Speed
	{
		get => speed;
		set
		{
			speed = value;
			player.Speed = speed;
		}
	}

	private void Awake()
	{
		player = GetComponent<Player>();
		rb = GetComponent<Rigidbody>();
	}

	void Start()
	{
		
	}

	void Update()
	{
		horizontalInput = SimpleInput.GetAxis("Horizontal");
		Debug.Log(horizontalInput);
		currentSteerAngle = maxSteerAngle * horizontalInput * 0.2f;

		if (verticalInput < 0)
		{
			isBreaking = true;
		}
		else
		{
			isBreaking = false;
		}

		Speed = rb.velocity.magnitude;
	}

	private void FixedUpdate()
	{
		HandleSteering();
		HandleMotor();
	}

	private void HandleSteering()
	{
		fLWheelCollider.steerAngle = currentSteerAngle;
		fRWheelCollider.steerAngle = currentSteerAngle;
	}

	private void HandleMotor()
	{
		if (!isBreaking)
		{
			rLWheelCollider.motorTorque = motorTorque;
			rRWheelCollider.motorTorque = motorTorque;
		}
	}
}
