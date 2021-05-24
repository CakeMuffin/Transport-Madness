using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCleanup : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		foreach (var carSpawner in FindObjectsOfType<ObstacleCarSpawner>())
		{
			carSpawner.CanSpawn = false;
		}

		foreach (var cars in GameObject.FindGameObjectsWithTag("Car"))
		{
			Destroy(cars);
		}
	}
}
