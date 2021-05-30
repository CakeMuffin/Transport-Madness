using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
	[SerializeField] private bool spawnAllowed = true;

	private List<RoadSection> roadSections = new List<RoadSection>();
	private List<CarSpawnTrigger> carSpawnTriggers = new List<CarSpawnTrigger>();

	public static ObstaclesManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
		carSpawnTriggers = FindObjectsOfType<CarSpawnTrigger>().ToList();
	}

	void Start()
	{
		roadSections = FindObjectsOfType<RoadSection>().ToList();
		GameManager.Instance.OnNewRun += PrepareNewRun;
	}

	public void PrepareNewRun()
	{
		CleanupCars();
		RespawnObstacles();
	}

	public void CleanupCars()
	{
		foreach (var carSpawnTrigger in carSpawnTriggers)
		{
			carSpawnTrigger.ResetTrigger();
		}

		foreach (var cars in GameObject.FindGameObjectsWithTag("Car"))
		{
			Destroy(cars);
		}

		foreach (var roadSection in roadSections)
		{
			roadSection.SpawnCars(false);
		}
	}

	private void RespawnObstacles()
	{
		if (spawnAllowed)
		{
			foreach (var obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
			{
				Destroy(obstacle);
			}

			foreach (var obstacles in FindObjectsOfType<RoadWithObstacles>())
			{
				obstacles.SpawnObstacles();
			}
		}
	}
}