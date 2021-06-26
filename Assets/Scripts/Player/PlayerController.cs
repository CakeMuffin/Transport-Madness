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

	public float Speed
	{
		get => speed;
		set
		{
			speed = value;
			player.Speed = speed;
		}
	}

	public float RPM { get; set; }

	private void Awake()
	{
		player = GetComponent<Player>();
		rb = GetComponent<Rigidbody>();
		carAudio = GetComponent<CarAudio>();
	}

	void Start()
	{
		
	}

	void Update()
	{
		horizontalInput = SimpleInput.GetAxis("Horizontal");
		currentSteerAngle = maxSteerAngle * horizontalInput * 0.2f;

		Speed = rb.velocity.magnitude;
		RPM = rRWheelCollider.rpm;

		UpdateWheelsPoses();
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

	private void OnCollisionEnter(Collision collision)
	{
		if (Speed > 10 && collision != null && !collision.gameObject.CompareTag("Crate"))
		{
			carAudio.PlayCrashSound();
		}
	}
}
