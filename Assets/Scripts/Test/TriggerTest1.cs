using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest1 : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<Rigidbody>().sleepThreshold = 0;
	}
}
