using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> obstaceCarsPrefabs;


	public static ResourcesManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	public List<GameObject> GetObstaceCarsPrefabs()
	{
		return obstaceCarsPrefabs;
	}

}
