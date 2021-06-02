using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{
	private Player player;

	private void Awake()
	{
		player = GetComponentInParent<Player>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Crate"))
		{
			player.CratesInTrunk.Add(other.gameObject);
			player.CratesCountChange();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Crate"))
		{
			player.CratesInTrunk.Remove(other.gameObject);
			player.CratesCountChange();
		}
	}
}
