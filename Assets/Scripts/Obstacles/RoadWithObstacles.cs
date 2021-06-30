using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadWithObstacles : MonoBehaviour
{
	[SerializeField] private int spawnAttemptsMax;
	[SerializeField] private float difficultyCoefficient;
	[SerializeField, Header("Base obstacle amounts")] private int smallAmount;
	[SerializeField] private int mediumAmount;
	[SerializeField] private int bigAmount;
	[SerializeField, Header("Safe zones")] private float smallSafeZone;
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
	}

	public void SpawnObstacles()
	{
		SpawnBigObstacles();
		SpawnMediumObstacles();
		SpawnSmallObstacles();
	}

	private void SpawnBigObstacles()
	{
		//int amount = Mathf.RoundToInt(bigAmount * difficultyCoefficient * GameManager.Instance.RunNumber);
		int amount = Mathf.RoundToInt(Mathf.LerpUnclamped(bigAmount, bigAmount * difficultyCoefficient, GameManager.Instance.RunNumber));

		//Debug.Log(amount);

		for (int i = 0; i < amount; i++)
		{
			bool validPosition = false;
			int spawnAttempts = 0;

			while (!validPosition && spawnAttempts < spawnAttemptsMax)
			{
				spawnAttempts++;

				float randX = Random.Range(-6f, 6f);
				float randZ = Random.Range(-2f, -48f);
				randPos = new Vector3(randX, 1, randZ);
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
		//int amount = Mathf.RoundToInt(mediumAmount * difficultyCoefficient * GameManager.Instance.RunNumber);
		int amount = Mathf.RoundToInt(Mathf.LerpUnclamped(mediumAmount, mediumAmount * difficultyCoefficient, GameManager.Instance.RunNumber));
		//Debug.Log(amount);

		for (int i = 0; i < amount; i++)
		{
			bool validPosition = false;
			int spawnAttempts = 0;

			while (!validPosition && spawnAttempts < spawnAttemptsMax)
			{
				spawnAttempts++;

				float randX = Random.Range(-7.2f, 7.2f);
				float randZ = Random.Range(-1f, -49f);
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
		//int amount = Mathf.RoundToInt(smallAmount * difficultyCoefficient * GameManager.Instance.RunNumber);

		int amount = Mathf.RoundToInt(Mathf.LerpUnclamped(smallAmount, smallAmount * difficultyCoefficient, GameManager.Instance.RunNumber));

		//Debug.Log(amount);

		for (int i = 0; i < amount; i++)
		{
			bool validPosition = false;
			int spawnAttempts = 0;

			while (!validPosition && spawnAttempts < spawnAttemptsMax)
			{
				spawnAttempts++;

				float randX = Random.Range(-7.8f, 7.8f);
				float randZ = Random.Range(-0.5f, -49.5f);
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