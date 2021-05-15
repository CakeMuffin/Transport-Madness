using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> obstaceCarsPrefabs;
	[SerializeField] private List<GameObject> obstaceObjectsPrefabs;


	public static ResourcesManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	public List<GameObject> GetObstaceCarsPrefabs()
	{
		return obstaceCarsPrefabs;
	}

	public List<GameObject> GetObstaceObjectsPrefabs()
	{
		return obstaceObjectsPrefabs;
	}

	public GameObject GetRandomObstaceObjectPrefab()
	{
		int randObstacle = Random.Range(0, obstaceObjectsPrefabs.Count);
		return obstaceObjectsPrefabs[randObstacle];
	}
}
