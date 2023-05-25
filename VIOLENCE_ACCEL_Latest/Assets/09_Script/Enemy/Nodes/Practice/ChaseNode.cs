using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private EnemyAI ai;

    public ChaseNode(Transform _target, NavMeshAgent _agent, EnemyAI _ai)
    {
        this.target = _target;
        this.agent = _agent;
        this.ai = _ai;
    }

    public override NodeState Evaluate()
    {
        ai.SetColor(Color.yellow);
        float distance = Vector3.Distance(target.position, agent.transform.position);

        

        if(distance > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);

            Debug.Log("ChaseNode / í«ê’íÜ");
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;

            Debug.Log("ChaseNode / í«ê’äÆóπ");
            return NodeState.SUCCESS;
        }
    }
}
