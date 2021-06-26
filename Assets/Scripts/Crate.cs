using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] List<AudioClip> rattles;

    AudioSource audioSource;
	Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (rb.velocity.magnitude > 6 && collision != null)
		{
			AudioClip randRattle = rattles[Random.Range(0, rattles.Count)];
			audioSource.clip = randRattle;
			audioSource.Play();
		}
	}
}
