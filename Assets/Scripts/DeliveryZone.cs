using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DeliveryZone : MonoBehaviour
{
	[SerializeField] private GameObject cratesPrefab;
	[SerializeField] private int moneyPerCrate = 50;
	[SerializeField] private PlayableDirector timeline;

	private Player player;
	private int cratesUnloaded = 0;

	private void Awake()
	{
		player = GameManager.Instance.player;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameManager.Instance.InCutscene = true;
			timeline.Play();
			other.attachedRigidbody.isKinematic = true;
		}

		if (other.CompareTag("Crate"))
		{
			other.attachedRigidbody.isKinematic = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.attachedRigidbody.isKinematic = false;
		}

		if (other.CompareTag("Crate"))
		{
			other.attachedRigidbody.isKinematic = false;
		}
	}

	private void AddMoney()
	{
		cratesUnloaded = GameManager.Instance.player.CratesInTrunk.Count;
		GameManager.Instance.AddMoney(moneyPerCrate * cratesUnloaded);
	}

	// Timeline
	public void UnloadCrates()
	{
		AddMoney();
		player.ClearCratesInTrunk();
		GameManager.Instance.CratesUnloaded(cratesUnloaded);
	}

	// Timeline
	public void LoadCrates()
	{
		Instantiate(cratesPrefab, player.trunk.transform); 
	}
}
