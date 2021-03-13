using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent agent;
    public EnemyClass ec;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(ec.Target.position - (ec.Target.position - gameObject.transform.position).normalized * 3f);
    }
}
