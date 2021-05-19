using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool InCutscene { get; set; } = true;
	public Player player;

	private int money = 0;

	public static GameManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		AddMoney(0);
	}

	private void Update()
	{
		CheckSpeed();
	}

	private void CheckSpeed()
	{
		if (player.Speed < 0.1f && !InCutscene)
		{
			Debug.Log("Captain Slow");
		}
	}

	public void AddMoney(int value)
	{
		money += value;
		UiManager.Instance.SetMoney(money);
	}

	// Timeline
	public void HahdleCutsceneEnter()
	{
		InCutscene = true;
	}

	// Timeline
	public void HahdleCutsceneExit()
	{
		InCutscene = false;
	}
}
