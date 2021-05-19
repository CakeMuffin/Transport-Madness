using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueModalWindow : MonoBehaviour
{
	[SerializeField] private Image bossAvatar;
	[SerializeField] private TMP_Text bodyText;
	[SerializeField] private Button button;
	[SerializeField] private Animator animator;

	private Dialogue dialogue;

	public void ToggleWindow(Dialogue dialogue)
	{
		animator.Play("Open");

		SetDialogue(dialogue);
	}

	public void TriggerWindow(Dialogue dialogue)
	{
		animator.Play("OpenClose");
		SetDialogue(dialogue);
	}

	public void SetDialogue(Dialogue dialogue)
	{
		this.dialogue = dialogue;
		bossAvatar.sprite = dialogue.bossAvatar;
		bodyText.SetText(dialogue.bodyText);

		button.gameObject.SetActive(dialogue.inteactable);
	}

	public void HandleOk()
	{
		animator.Play("Idle");

		GameManager.Instance.Restart();
	}
}
