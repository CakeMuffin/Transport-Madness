using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	public List<GameObject> CratesInTrunk { get; set; } = new List<GameObject>();
	public Trunk trunk;
	public float Speed { get; set; }

	private UiManager uiManager;

	public event UnityAction OnCratesChanged;

	private void Awake()
	{
		trunk = GetComponentInChildren<Trunk>();
	}

	void Start()
	{
		uiManager = UiManager.Instance;
		GameManager.Instance.OnFail += ClearCratesInTrunk;
	}

	public void CratesCountChange()
	{
		OnCratesChanged?.Invoke();
	}

	public void ClearCratesInTrunk()
	{
		foreach (var crate in CratesInTrunk)
		{
			Destroy(crate);
		}

		CratesInTrunk.Clear();

		OnCratesChanged?.Invoke();
	}
}
