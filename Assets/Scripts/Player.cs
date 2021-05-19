using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float Speed { get; set; }
	public List<GameObject> CratesInTrunk { get; set; } = new List<GameObject>();
	public GameObject trunk;

	private CarCratesCounter cratesCounter;
	private UiManager uiManager;

	private void Awake()
	{
		cratesCounter = GetComponentInChildren<CarCratesCounter>();
	}

	void Start()
	{
		uiManager = UiManager.Instance;
	}

	public void UpdateCrates()
	{
		uiManager.HandleCratesCountChange(CratesInTrunk.Count);
	}

	public void ClearCratesInTrunk()
	{
		CratesInTrunk.Clear();

	}
}
