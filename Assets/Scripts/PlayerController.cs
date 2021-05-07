using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed = 10f;

	private InputManager inputManager;
	private Rigidbody rb;

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
		Vector3 verticalInput = new Vector3(0, 0, inputManager.GetPlayerMovement().y * speed);
		Vector3 horizontalInput = new Vector3(0, inputManager.GetPlayerMovement().x * speed * 3, 0);

		rb.AddRelativeForce(verticalInput);
		rb.AddRelativeTorque(horizontalInput);
	}
}
