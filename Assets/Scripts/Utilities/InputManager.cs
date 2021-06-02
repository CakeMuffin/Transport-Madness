using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	PlayerControls playerControlls;
	bool firing = false;
	bool aiming = false;
	private float mouseSens = 4;

	public static InputManager Instance { get; set; }

	void Awake()
	{
		Instance = this;
		playerControlls = new PlayerControls();	
	}

	private void Update()
	{
		//HoldButtons();
	}

	private void OnEnable()
	{
		playerControlls.Enable();
	}

	private void OnDisable()
	{
		playerControlls.Disable();
	}


	public Vector2 GetPlayerMovement()
	{
		return playerControlls.Player.Move.ReadValue<Vector2>();
	}

	public bool GetDebug()
	{
		return playerControlls.Player.Debug.triggered;
	}

	/*
	public Vector2 GetMouseDelta()
	{
		return playerControlls.Player.Look.ReadValue<Vector2>();
	}

	public bool GetFire()
	{
		return firing;
	}

	private void HoldButtons()
	{
		if (playerControlls.Player.Fire.triggered)
		{
			firing = !firing;
		}
	}
	*/
}
