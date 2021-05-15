using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesOnRoad : MonoBehaviour
{
	[SerializeField] private int obstaclesPerSegmentMax = 3;

	private ResourcesManager resourcesManager;

	private void Start()
	{
		resourcesManager = ResourcesManager.Instance;

		SpawnObstacles();
	}

	public void SpawnObstacles()
	{
		for (int i = 0; i < obstaclesPerSegmentMax; i++)
		{
			float dice = Random.value;

			if (dice >= 0.5f)
			{
				float randX = Random.Range(-6.5f, 6.5f);
				float randZ = Random.Range(2f, 46f);

				Vector3 randPos = new Vector3(randX, 1, randZ);
				var obstacle = Instantiate(resourcesManager.GetRandomObstaceObjectPrefab(), transform);

				obstacle.transform.localPosition = randPos;
			}
		}
	}
}
