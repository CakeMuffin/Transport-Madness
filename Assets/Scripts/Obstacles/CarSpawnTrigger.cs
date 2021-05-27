using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnTrigger : MonoBehaviour
{
	private RoadSection roadSection;
	private bool spawning = false;

	private void Awake()
	{
		roadSection = GetComponentInParent<RoadSection>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (!spawning)
			{
				ObstaclesManager.Instance.CleanupCars();
				spawning = true;
				roadSection.SpawnCars(true);
			}
		}
	}

	public void ResetTrigger()
	{
		spawning = false;
	}
}
