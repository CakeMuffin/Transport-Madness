using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSection : MonoBehaviour
{
	[SerializeField, Range(1f, 10f)] private float spawnEvery;

	private List<GameObject> roadCarSpawner;
	private List<GameObject> obstaceCarsPrefabs;

	private void Awake()
	{
		roadCarSpawner = GameObject.FindGameObjectsWithTag("CarsSpawner").ToList().FindAll(x => x.transform.IsChildOf(transform));
	}

	void Start()
	{
		obstaceCarsPrefabs = ResourcesManager.Instance.GetCars();
	}

	public void SpawnCars(bool canSpawn)
	{
		if (canSpawn)
		{
			InvokeRepeating(nameof(SpawnCar), 0, spawnEvery);
			Debug.Log("Start spawining");
		}
		else
		{
			CancelInvoke(nameof(SpawnCar));
		}
	}

	private void SpawnCar()
	{
		int randSpawnPoint = Random.Range(0, roadCarSpawner.Count);

		GameObject randCar = obstaceCarsPrefabs[Random.Range(0, obstaceCarsPrefabs.Count)];
		Instantiate(randCar, roadCarSpawner[randSpawnPoint].transform.position, roadCarSpawner[randSpawnPoint].transform.rotation);
	}
}
