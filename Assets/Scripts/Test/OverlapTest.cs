using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapTest : MonoBehaviour
{
	[SerializeField] LayerMask obstacleLayer;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		RaycastHit hit;
		if (Physics.SphereCast(transform.position, 3, Vector3.zero, out hit))
		{
			if (hit.collider.gameObject != gameObject)
			{
				//validPosition = false;
				//Debug.Log("Collision");
			}

			Debug.Log(hit.collider.name);
		}

		/*
		RaycastHit hit;
		if (Physics.SphereCast(transform.position, 3, Vector3.zero, out hit, Mathf.Infinity, obstacleLayer, QueryTriggerInteraction.UseGlobal))
		{
			if (hit.collider.gameObject != gameObject)
			{
				//validPosition = false;
				//Debug.Log("Collision");
			}

			//Debug.Log(hit.collider.gameObject.name);
		}
		Debug.Log(hit.collider);
		*/
	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 3);
	}
}
