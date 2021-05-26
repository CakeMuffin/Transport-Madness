using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
	[SerializeField] private bool spawnAllowed = true;

	private List<RoadSection> roadSections = new List<RoadSection>();

	public static ObstaclesManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		roadSections = FindObjectsOfType<RoadSection>().ToList();
	}

	public void SpawnObstacles()
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

	public void CleanupCars()
	{
		foreach (var cars in GameObject.FindGameObjectsWithTag("Car"))
		{
			Destroy(cars);
		}

		foreach (var roadSection in roadSections)
		{
			roadSection.SpawnCars(false);
		}
	}
}