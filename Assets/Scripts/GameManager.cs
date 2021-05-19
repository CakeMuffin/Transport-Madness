using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool InCutscene { get; set; } = true;
	public Player player;

	[SerializeField] private Transform restartPos;

	private int money = 0;
	private bool failed = false;

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
		if (player.Speed < 0.1f && !InCutscene && !failed)
		{
			HandleFail();
		}
	}

	private void HandleFail()
	{
		DialogueManager.Instance.HandleFail();
		failed = true;
	}

	public void AddMoney(int value)
	{
		money += value;
		UiManager.Instance.SetMoney(money);
	}

	// Timeline
	public void HahdleCutsceneEnter()
	{
		//DialogueManager.Instance.HandleCutsceneStart();
	}

	// Timeline
	public void HahdleCutsceneExit()
	{
		InCutscene = false;

		DialogueManager.Instance.HandleCutsceneEnd();
	}

	public void Restart()
	{
		ClearAllCrates();

		InCutscene = false;
		player.transform.position = restartPos.position;
	}

	public void CratesUnloaded(int crates)
	{
		failed = false;
		ClearAllCrates();
		DialogueManager.Instance.HandleCutsceneUnload(crates);
	}

	public void ClearAllCrates()
	{
		foreach (var crate in GameObject.FindGameObjectsWithTag("Crate"))
		{
			Destroy(crate);
		}
	}
}
