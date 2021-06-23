using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
	[SerializeField] private PauseMenu pauseMenu;
	[SerializeField] private TMP_Text cratesText;
	[SerializeField] private TMP_Text moneyText;

	public static UiManager Instance { get; set; }

	private GameManager gameManager;

	private void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		gameManager = GameManager.Instance;
		gameManager.OnMoneyChange += HandleMoneyChange;
		gameManager.player.OnCratesChanged += HandleCratesCountChange;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.isActiveAndEnabled)
		{
			pauseMenu.gameObject.SetActive(true);
		}
	}

	public void HandleCratesCountChange()
	{
		cratesText.SetText(gameManager.player.CratesInTrunk.Count.ToString());
	}

	public void HandleMoneyChange()
	{
		moneyText.SetText(gameManager.Money.ToString());
	}
}
