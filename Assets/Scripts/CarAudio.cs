using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
	[SerializeField] AudioSource audioSourceEngine;
	[SerializeField] AudioSource audioSourceMisc;
	[SerializeField] AudioClip crash;

	[SerializeField] float pitchMin = 1f;
	[SerializeField] float pitchMax = 6f;
	[SerializeField] float pitchMultiplier = 1f;

	PlayerController playerController;

	private void Awake()
	{
		playerController = GetComponent<PlayerController>();
	}

	private void Update()
	{
		float pitch = Mathf.LerpUnclamped(pitchMin, pitchMax, playerController.Speed);
		audioSourceEngine.pitch = pitch * pitchMultiplier;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (playerController.Speed > 15 && collision != null && !collision.gameObject.CompareTag("Crate"))
		{
			PlayCrashSound();
		}
	}

	public void PlayCrashSound()
	{
		audioSourceMisc.clip = crash;
		audioSourceMisc.Play();
	}
}
