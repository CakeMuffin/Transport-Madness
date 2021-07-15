using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	public bool InCutscene { get; set; } = true;
	public bool Failed { get; set; } = false;

	public Player player;
	public int Money { get; set; } = 0;
	public int RunNumber { get; set; } = 0;

	public event UnityAction OnCutsceneEnter;
	public event UnityAction OnCutsceneExit;
	public event UnityAction OnNewRun;
	public event UnityAction OnCratesUnload;
	public event UnityAction OnCratesLoad;
	public event UnityAction OnFail;
	public event UnityAction OnMoneyChange;

	[SerializeField] Transform restartPos;

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
		if (Input.GetKeyDown(KeyCode.R))
		{
			player.transform.position = restartPos.position;
		}

		CheckFailCondition();
	}

	private void CheckFailCondition()
	{
		if (player.Speed < 0.1f && !InCutscene && !Failed)
		{
			HandleFail();
		}
	}

	private void HandleFail()
	{
		Failed = true;
		OnFail?.Invoke();
	}

	public void AddMoney(int value)
	{
		Money += value;
		OnMoneyChange?.Invoke();
	}

	public void ClearMoney()
	{
		Money = 0;
		OnMoneyChange?.Invoke();
	}

	public void CutsceneEnter()
	{
		OnCutsceneEnter?.Invoke();
		NewRun();
	}

	public void CutsceneExit()
	{
		Invoke(nameof(DelayedCutsceneExit), 1.5f);
		OnCutsceneExit?.Invoke();
	}

	// To get a chance to speedup before checking to fail stop.
	private void DelayedCutsceneExit()
	{
		InCutscene = false;
	}

	// OK modal window.
	public void Restart()
	{
		NewRun();

		ClearMoney();
		RunNumber = 0;
	}

	private void NewRun()
	{
		Failed = false;
		ClearDroppedCrates();
		OnNewRun?.Invoke();
		player.transform.position = restartPos.position;
		RunNumber++;
	}

	public void CratesUnloaded()
	{
		OnCratesUnload?.Invoke();
		if (Money > PlayerPrefs.GetInt("Money"))
		{
			PlayerPrefs.SetInt("Money", Money);
		}
	}

	public void CratesLoaded()
	{
		OnCratesLoad?.Invoke();
	}

	public void ClearDroppedCrates()
	{
		// Can be optimized with 2 lists.
		foreach (var crate in GameObject.FindGameObjectsWithTag("Crate"))
		{
			if (!player.CratesInTrunk.Contains(crate))
			{
				Destroy(crate);
			}
		}
	}
}
