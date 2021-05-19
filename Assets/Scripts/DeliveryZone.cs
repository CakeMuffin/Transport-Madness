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

	private void Awake()
	{
		player = GameManager.Instance.player;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
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
		int cratesQuantity = GameManager.Instance.player.CratesInTrunk.Count;
		GameManager.Instance.AddMoney(moneyPerCrate * cratesQuantity);
	}

	// Timeline
	public void ClearCratesFromTrunk()
	{
		AddMoney();
		player.ClearCratesInTrunk();

		foreach (var crate in GameObject.FindGameObjectsWithTag("Crate"))
		{
			Destroy(crate);
		}
	}

	// Timeline
	public void LoadCratesToTrunk()
	{
		Instantiate(cratesPrefab, player.trunk.transform); 
	}
}
