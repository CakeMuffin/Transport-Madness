using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCarSpawner : MonoBehaviour
{
	public bool CanSpawn { get; set; } = false;

	[SerializeField] private float repeatEvery = 3f;
	private List<GameObject> obstaceCarsPrefabs;

	void Start()
	{
		obstaceCarsPrefabs = ResourcesManager.Instance.GetCars();

		InvokeRepeating(nameof(SpawnObstacleCar), 0.1f, repeatEvery);
	}

	private void SpawnObstacleCar()
	{
		if (CanSpawn)
		{
			GameObject randCar = obstaceCarsPrefabs[Random.Range(0, obstaceCarsPrefabs.Count)];
			Instantiate(randCar, transform.position, transform.rotation);
		}
	}
}
