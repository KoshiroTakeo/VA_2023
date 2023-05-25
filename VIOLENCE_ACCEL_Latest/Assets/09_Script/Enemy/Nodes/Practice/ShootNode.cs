using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI ai;

    public ShootNode(NavMeshAgent _agent, EnemyAI _ai)
    {
        this.agent = _agent;
        this.ai = _ai;
    }

    public override NodeState Evaluate()
    {
        
        agent.isStopped = true;
        ai.SetColor(Color.red);

        Debug.Log("ShootNode / çUåÇíÜ");
        return NodeState.RUNNING;
    }
}
