using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{


	public static ObstaclesManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		
	}

	public void SpawnObstacles()
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