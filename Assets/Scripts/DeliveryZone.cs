using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DeliveryZone : MonoBehaviour
{
	[SerializeField] private int moneyPerCrate = 50;
	[SerializeField] private PlayableDirector timeline;

	private PlayerController playerController;

	private bool cratesDelivered = false;

	private void Awake()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	/*
	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Crate"))
		{
			AddMoney();
			Destroy(other.gameObject);
		}
	}
	*/

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			timeline.Play();
			other.attachedRigidbody.isKinematic = true;
		}

		if (other.CompareTag("Crate"))
		{
			AddMoney();
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
		GameManager.Instance.AddMoney(moneyPerCrate);
	}
}
