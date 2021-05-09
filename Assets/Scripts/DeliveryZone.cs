using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
	[SerializeField] private int moneyPerCrate = 50;
	private PlayerController playerController;

	private bool cratesDelivered = false;

	private void Awake()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	private void OnTriggerStay(Collider other)
	{
		if (playerController.Speed < 0.3f)
		{
			if (other.CompareTag("Crate"))
			{
				AddMoney();
				Destroy(other.gameObject);
			}
		}
	}

	private void AddMoney()
	{
		GameManager.Instance.AddMoney(moneyPerCrate);
	}
}
