using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnTrigger : MonoBehaviour
{
	[SerializeField] List<GameObject> roadCarSpawner;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			foreach (var carSpawner in roadCarSpawner)
			{
				carSpawner.GetComponentInChildren<ObstacleCarSpawner>().CanSpawn = true;
			}
		}
	}
}
