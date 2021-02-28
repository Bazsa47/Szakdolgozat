using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GetComponent<EnemyClass>().Target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            target = GameObject.FindWithTag("Player").transform;
        agent.SetDestination(target.position);
    }
}
