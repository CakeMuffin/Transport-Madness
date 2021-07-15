using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
	private const string leaderboardId = "CgkIk7zo9NUFEAIQAQ";

	void Start()
	{
		PlayGamesPlatform.DebugLogEnabled = true;
		if (!PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Activate();
			Social.localUser.Authenticate(success =>
			{
				if (success)
				{

				}
				else
				{

				}
			});
		}
		
		Application.quitting += ExitFromGPS;
		GameManager.Instance.OnCratesUnload += RecordScores;
	}

	void RecordScores()
	{
		Social.ReportScore(GameManager.Instance.Money, leaderboardId, (bool success) => { });
	}

	public void ShowLeaderboard()
	{
		Social.ShowLeaderboardUI();
	}

	public void ExitFromGPS()
	{
		PlayGamesPlatform.Instance.SignOut();
	}
}
