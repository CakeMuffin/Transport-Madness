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

	[Header("Wheels Visual")]
	[SerializeField] private Transform fLWheel;
	[SerializeField] private Transform fRWheel;
	[SerializeField] private Transform rLWheel;
	[SerializeField] private Transform rRWheel;

	private Player player;
	private Rigidbody rb;
	private CarAudio carAudio;

	private float horizontalInput;
	private float currentSteerAngle;
	private float speed;
	private bool wheelSpinState = true;

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
		carAudio = GetComponent<CarAudio>();
	}

	void Start()
	{
		GameManager.Instance.OnCutsceneEnter += SpinWheels;
		GameManager.Instance.OnCratesUnload += StopSpinWheels;
		GameManager.Instance.OnCratesLoad += SpinWheels;
	}

	void Update()
	{
		if (!GameManager.Instance.Failed)
		{
			horizontalInput = SimpleInput.GetAxis("Horizontal");
		}
		currentSteerAngle = maxSteerAngle * horizontalInput * 0.2f;

		Speed = rb.velocity.magnitude;

		UpdateWheelsPoses();

		if (!GameManager.Instance.InCutscene)
		{
			fLWheelCollider.motorTorque = 0;
			fRWheelCollider.motorTorque = 0;
		}
	}

	private void UpdateWheelsPoses()
	{
		UpdateWheelPose(fLWheelCollider, fLWheel);
		UpdateWheelPose(fRWheelCollider, fRWheel);
		UpdateWheelPose(rLWheelCollider, rLWheel);
		UpdateWheelPose(rRWheelCollider, rRWheel);
	}

	private	void UpdateWheelPose(WheelCollider wheelCollider, Transform wheelVisual)
	{
		Vector3 pos = wheelVisual.position;
		Quaternion rot = wheelVisual.rotation;

		wheelCollider.GetWorldPose(out pos, out rot);

		wheelVisual.position = pos;
		wheelVisual.rotation = rot;
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
		rLWheelCollider.motorTorque = motorTorque;
		rRWheelCollider.motorTorque = motorTorque;

	}

	private void SpinWheels()
	{
		fLWheelCollider.brakeTorque = 0;
		fRWheelCollider.brakeTorque = 0;
		rLWheelCollider.brakeTorque = 0;
		rRWheelCollider.brakeTorque = 0;

		fLWheelCollider.motorTorque = motorTorque;
		fRWheelCollider.motorTorque = motorTorque;
	}

	private void StopSpinWheels()
	{
		fLWheelCollider.motorTorque = 1;
		fRWheelCollider.motorTorque = 1;
		rLWheelCollider.motorTorque = 1;
		rRWheelCollider.motorTorque = 1;


		fLWheelCollider.brakeTorque = 10000;
		fRWheelCollider.brakeTorque = 10000;
		rLWheelCollider.brakeTorque = 10000;
		rRWheelCollider.brakeTorque = 10000;		
	}
}
