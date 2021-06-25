using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private TMP_Text RecordText;	

	private void OnEnable()
	{
		Time.timeScale = 0;
		RecordText.SetText(PlayerPrefs.GetInt("Money", 0).ToString());
	}

	private void OnDisable()
	{
		Time.timeScale = 1;
	}
}