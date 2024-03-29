using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomEnemy : MonoBehaviour
{
	private NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		if (agent.hasPath || agent.remainingDistance > 0.1f) return;
		else
		{
			agent.SetDestination((Random.insideUnitSphere * 10) +
					transform.position);
		}
	}

}
