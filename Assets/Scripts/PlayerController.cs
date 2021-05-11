using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float motorTorque;
	[SerializeField] private float maxBreakForce;
	[SerializeField] private float maxSteerAngle;
	[SerializeField] private WheelCollider fLWheelCollider;
	[SerializeField] private WheelCollider fRWheelCollider;
	[SerializeField] private WheelCollider rLWheelCollider;
	[SerializeField] private WheelCollider rRWheelCollider;

	private InputManager inputManager;
	private Rigidbody rb;

	private float verticalInput;
	private float horizontalInput;
	private bool isBreaking = false;
	private float currentSteerAngle;
	private float currentBreakForce;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Start()
	{
		inputManager = InputManager.Instance;
	}

	void Update()
	{
		currentSteerAngle = maxSteerAngle * horizontalInput;
		verticalInput = inputManager.GetPlayerMovement().y;
		horizontalInput = inputManager.GetPlayerMovement().x;
		currentBreakForce = isBreaking ? maxBreakForce : 0;

		if (verticalInput < 0)
		{
			isBreaking = true;
		}
		else
		{
			isBreaking = false;
		}
	}

	private void FixedUpdate()
	{
		HandleSteering();
		HandleMotor();
		HandleBreaking();
	}

	private void HandleBreaking()
	{
		if (isBreaking)
		{
			rLWheelCollider.motorTorque = 0;
			rRWheelCollider.motorTorque = 0;

			fLWheelCollider.brakeTorque = currentBreakForce;
			fRWheelCollider.brakeTorque = currentBreakForce;
			rLWheelCollider.brakeTorque = currentBreakForce;
			rRWheelCollider.brakeTorque = currentBreakForce;
		}
		else
		{
			fLWheelCollider.brakeTorque = 0;
			fRWheelCollider.brakeTorque = 0;
			rLWheelCollider.brakeTorque = 0;
			rRWheelCollider.brakeTorque = 0;
		}
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
