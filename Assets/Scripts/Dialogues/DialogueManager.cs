using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	[SerializeField] private DialogueModalWindow dialogueWindow;

	[SerializeField] private Dialogue startDialogue;
	[SerializeField] private Dialogue unloadDialogue0;
	[SerializeField] private Dialogue unloadDialogue;
	[SerializeField] private Dialogue unloadDialogue20;
	[SerializeField] private Dialogue failDialogue;

	private GameManager gameManager;
	private bool firstTime = true;

	public static DialogueManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		gameManager = GameManager.Instance;

		gameManager.OnCratesUnload += HandleCutsceneUnload;
		gameManager.OnFail += HandleFail;
		gameManager.OnCutsceneExit += HandleCutsceneEnd;
	}

	public void HandleCutsceneStart()
	{
		
	}

	public void HandleCutsceneUnload()
	{
		if (!firstTime)
		{
			if (gameManager.player.CratesInTrunk.Count == 0)
			{
				dialogueWindow.TriggerWindow(unloadDialogue0);
			}
			else if (gameManager.player.CratesInTrunk.Count == 20)
			{
				dialogueWindow.TriggerWindow(unloadDialogue20);
			}
			else
			{
				dialogueWindow.TriggerWindow(unloadDialogue);
			}
		}

		firstTime = false;
	}

	public void HandleCutsceneEnd()
	{
		dialogueWindow.TriggerWindow(startDialogue);
	}

	public void HandleFail()
	{
		dialogueWindow.ToggleWindow(failDialogue);
		firstTime = true;
	}
}
