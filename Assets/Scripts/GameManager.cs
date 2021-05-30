using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	public bool InCutscene { get; set; } = true;
	public Player player;

	[SerializeField] private Transform restartPos;

	public int Money { get; set; } = 0;
	private bool failed = false;

	public event UnityAction OnCutsceneEnter;
	public event UnityAction OnCutsceneExit;
	public event UnityAction OnNewRun;
	public event UnityAction OnCratesUnload;
	public event UnityAction OnFail;
	public event UnityAction OnMoneyChange;

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
		CheckFailCondition();
	}

	private void CheckFailCondition()
	{
		if (player.Speed < 0.1f && !InCutscene && !failed)
		{
			HandleFail();
		}
	}

	private void HandleFail()
	{
		failed = true;
		OnFail?.Invoke();
	}

	public void AddMoney(int value)
	{
		Money += value;
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

		Money = 0;
	}

	private void NewRun()
	{
		failed = false;
		ClearDroppedCrates();
		OnNewRun?.Invoke();
		player.transform.position = restartPos.position;
	}

	public void CratesUnloaded()
	{
		OnCratesUnload?.Invoke();
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
