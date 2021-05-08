using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CarCratesCounter : MonoBehaviour
{
	private List<GameObject> crates = new List<GameObject>();

	private UiManager uiManager;

	void Start()
	{
		uiManager = UiManager.Instance;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Crate"))
		{
			crates.Add(other.gameObject);
		}

		uiManager.HandleCratesCountChange(crates.Count);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Crate"))
		{
			crates.Remove(other.gameObject);
		}

		uiManager.HandleCratesCountChange(crates.Count);
	}
}
