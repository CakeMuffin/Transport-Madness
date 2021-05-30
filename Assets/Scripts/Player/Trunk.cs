using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

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
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Crate"))
		{
			player.CratesInTrunk.Remove(other.gameObject);
		}
	}
}
