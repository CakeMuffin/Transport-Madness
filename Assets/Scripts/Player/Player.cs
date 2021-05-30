using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public List<GameObject> CratesInTrunk { get; set; } = new List<GameObject>();
	public GameObject trunk;
	public float Speed { get; set; }

	private UiManager uiManager;
	private Trunk cratesCounter;

	private void Awake()
	{
		cratesCounter = GetComponentInChildren<Trunk>();
	}

	void Start()
	{
		uiManager = UiManager.Instance;
	}

	public void ClearCratesInTrunk()
	{
		foreach (var crate in CratesInTrunk)
		{
			Destroy(crate);
		}

		CratesInTrunk.Clear();
	}
}
