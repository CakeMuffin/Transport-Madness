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

	private bool firstTime = true;

	public static DialogueManager Instance { get; set; }

	private void Awake()
	{
		Instance = this;
	}

	public void HandleCutsceneStart()
	{
		
	}

	public void HandleCutsceneUnload(int crates)
	{
		if (!firstTime)
		{
			if (crates == 0)
			{
				dialogueWindow.TriggerWindow(unloadDialogue0);
			}
			else if (crates == 20)
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
