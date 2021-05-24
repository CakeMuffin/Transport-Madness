using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> carsPrefabs;
	[SerializeField] private List<GameObject> smallObstacles;
	[SerializeField] private List<GameObject> mediumObstacles;
	[SerializeField] private List<GameObject> bigObstacles;

	public static ResourcesManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	public List<GameObject> GetCars()
	{
		return carsPrefabs;
	}

	public GameObject GetRandomSmallObstacle()
	{
		int randObstacle = Random.Range(0, smallObstacles.Count);
		return smallObstacles[randObstacle];
	}

	public GameObject GetRandomMediumObstacle()
	{
		int randObstacle = Random.Range(0, mediumObstacles.Count);
		return mediumObstacles[randObstacle];
	}

	public GameObject GetRandomBigObstacle()
	{
		int randObstacle = Random.Range(0, bigObstacles.Count);
		return bigObstacles[randObstacle];
	}
}