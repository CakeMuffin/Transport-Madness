using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Warehouse : MonoBehaviour
{
	[SerializeField] private GameObject cratesPrefab;
	[SerializeField] private int moneyPerCrate = 50;
	[SerializeField] private PlayableDirector timeline;

	private Player player;
	private int cratesUnloaded = 0;
	public bool InCutscene { get; set; } = false;


	private void Awake()
	{
		player = GameManager.Instance.player;
	}

	#region Timeline

	public void PlayCutscene()
	{
		if (!InCutscene)
		{
			InCutscene = true;
			// Had to fire InCutscene even earlier then timeline event to prevent fail event. 
			GameManager.Instance.InCutscene = true;
			timeline.Play();
		}
	}

	public void HahdleCutsceneEnter()
	{
		GameManager.Instance.CutsceneEnter();
	}

	public void HahdleCutsceneExit()
	{
		GameManager.Instance.CutsceneExit();
		InCutscene = false;
	}

	public void HandleUnloadingCrates()
	{
		AddMoney();
		GameManager.Instance.CratesUnloaded();
		DespawnCrates();
	}

	#endregion

	public void HandleLoadingCrates()
	{
		SpawnCrates();
		GameManager.Instance.CratesLoaded();
	}

	public void SpawnCrates()
	{
		Instantiate(cratesPrefab, player.trunk.transform);
	}

	public void DespawnCrates()
	{
		player.ClearCratesInTrunk();
	}

	private void AddMoney()
	{
		cratesUnloaded = GameManager.Instance.player.CratesInTrunk.Count;
		GameManager.Instance.AddMoney(moneyPerCrate * cratesUnloaded);
		cratesUnloaded = 0;
	}
}
