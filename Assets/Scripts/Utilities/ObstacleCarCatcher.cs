using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCarCatcher : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Car"))
		{
			Destroy(other.gameObject);
		}
	}
}
