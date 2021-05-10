using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCarSpawner : MonoBehaviour
{
    [SerializeField] private float repeatEvery = 3f;
    private List<GameObject> obstaceCarsPrefabs;

    void Start()
    {
        obstaceCarsPrefabs = ResourcesManager.Instance.GetObstaceCarsPrefabs();

        InvokeRepeating(nameof(SpawnObstacleCar), 0.1f, repeatEvery);
    }

    private void SpawnObstacleCar()
	{
        GameObject randCar = obstaceCarsPrefabs[Random.Range(0, obstaceCarsPrefabs.Count)];
        Instantiate(randCar, transform.position, transform.rotation);
	}
}
