using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
	[SerializeField] private TMP_Text cratesCounter;


	public static UiManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		
	}

	public void HandleCratesCountChange(int value)
	{
		cratesCounter.SetText(value.ToString());
	}
}
