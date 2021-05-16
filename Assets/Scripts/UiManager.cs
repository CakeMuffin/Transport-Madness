using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
	[SerializeField] private TMP_Text cratesText;
	[SerializeField] private TMP_Text moneyText;

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
		cratesText.SetText(value.ToString());
	}

	public void SetMoney(int value)
	{
		moneyText.SetText(value.ToString());
	}
}
