using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadWithObstacles : MonoBehaviour
{
	[SerializeField] private LayerMask obstacleLayer;
	[SerializeField] private int spawnAttemptsMax;
	[SerializeField] private int smallAmount;
	[SerializeField] private int mediumAmount;
	[SerializeField] private int bigAmount;
	[SerializeField] private float smallSafeZone;
	[SerializeField] private float mediumSafeZone;
	[SerializeField] private float bigSafeZone;

	private List<Vector3> bigObstaclesPos = new List<Vector3>();
	private List<Vector3> mediumObstaclesPos = new List<Vector3>();
	private List<Vector3> smallObstaclesPos = new List<Vector3>();

	private ResourcesManager resourcesManager;
	Vector3 randPos = Vector3.zero;

	private void Start()
	{
		resourcesManager = ResourcesManager.Instance;

		//SpawnObstacles();
	}

	public void SpawnObstacles()
	{
		SpawnBigObstacles();
		SpawnMediumObstacles();
		SpawnSmallObstacles();
	}

	private void SpawnBigObstacles()
	{
		for (int i = 0; i < bigAmount; i++)
		{
			bool validPosition = false;
			int spawnAttempts = 0;

			while (!validPosition && spawnAttempts < spawnAttemptsMax)
			{
				spawnAttempts++;

				float randX = Random.Range(-7.2f, 7.2f);
				float randZ = Random.Range(1f, 49f);
				randPos = new Vector3(randX, 2.5f, randZ);
				validPosition = true;

				foreach (var obstacle in bigObstaclesPos)
				{
					if (Vector3.Distance(obstacle, randPos) < bigSafeZone)
					{
						validPosition = false;
					}
				}
			}


			if (validPosition)
			{
				var obstacle = Instantiate(resourcesManager.GetRandomBigObstacle(), transform);
				obstacle.transform.position = randPos + transform.position;
				bigObstaclesPos.Add(randPos);
			}
		}
	}

	private void SpawnMediumObstacles()
	{
		for (int i = 0; i < mediumAmount; i++)
		{
			bool validPosition = false;
			int spawnAttempts = 0;

			while (!validPosition && spawnAttempts < spawnAttemptsMax)
			{
				spawnAttempts++;

				float randX = Random.Range(-7.2f, 7.2f);
				float randZ = Random.Range(1f, 49f);
				randPos = new Vector3(randX, 1, randZ);
				validPosition = true;

				foreach (var obstacle in bigObstaclesPos)
				{
					if (Vector3.Distance(obstacle, randPos) < mediumSafeZone)
					{
						validPosition = false;
					}
				}

				foreach (var obstacle in mediumObstaclesPos)
				{
					if (Vector3.Distance(obstacle, randPos) < mediumSafeZone)
					{
						validPosition = false;
					}
				}
			}


			if (validPosition)
			{
				var obstacle = Instantiate(resourcesManager.GetRandomMediumObstacle(), transform);
				obstacle.transform.position = randPos + transform.position;
				mediumObstaclesPos.Add(randPos);
			}
		}
	}

	private void SpawnSmallObstacles()
	{
		for (int i = 0; i < smallAmount; i++)
		{
			bool validPosition = false;
			int spawnAttempts = 0;

			while (!validPosition && spawnAttempts < spawnAttemptsMax)
			{
				spawnAttempts++;

				float randX = Random.Range(-7.8f, 7.8f);
				float randZ = Random.Range(0.5f, 49.5f);
				randPos = new Vector3(randX, 1, randZ);
				validPosition = true;

				foreach (var obstacle in bigObstaclesPos)
				{
					if (Vector3.Distance(obstacle, randPos) < smallSafeZone)
					{
						validPosition = false;
					}
				}

				foreach (var obstacle in mediumObstaclesPos)
				{
					if (Vector3.Distance(obstacle, randPos) < smallSafeZone)
					{
						validPosition = false;
					}
				}

				foreach (var obstacle in smallObstaclesPos)
				{
					if (Vector3.Distance(obstacle, randPos) < smallSafeZone)
					{
						validPosition = false;
					}
				}
			}


			if (validPosition)
			{
				var obstacle = Instantiate(resourcesManager.GetRandomSmallObstacle(), transform);
				obstacle.transform.position = randPos + transform.position;
				smallObstaclesPos.Add(randPos);
			}
		}
	}

}