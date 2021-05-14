using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWarehouse : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.transform.position = new Vector3(-1.4f, 1.6f, -57.9f);
		}
	}
}
