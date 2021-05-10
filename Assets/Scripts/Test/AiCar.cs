using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiCar : MonoBehaviour
{
    private NavMeshAgent agent;

	private void Awake()
	{
        agent = GetComponent<NavMeshAgent>();
    }

	void Start()
    {
        Vector3 localTarget = new Vector3(0, 0, transform.position.z + 250);
        Vector3 target = transform.TransformPoint(localTarget);
        agent.SetDestination(target);
        Debug.Log(agent.SetDestination(target));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
