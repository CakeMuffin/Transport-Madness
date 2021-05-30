using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
	private Warehouse warehouse;


	private void Awake()
	{
		warehouse = GetComponentInParent<Warehouse>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			warehouse.PlayCutscene();
			other.attachedRigidbody.isKinematic = true;
		}
		
		if (other.CompareTag("Crate"))
		{
			other.attachedRigidbody.isKinematic = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			//warehouse.HahdleCutsceneExit();
			other.attachedRigidbody.isKinematic = false;
		}
		
		if (other.CompareTag("Crate"))
		{
			other.attachedRigidbody.isKinematic = false;
		}
	}
}
