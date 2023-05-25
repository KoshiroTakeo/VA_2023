using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToCoverNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI ai;

    public GoToCoverNode(NavMeshAgent _agent, EnemyAI _ai)
    {
        this.agent = _agent;
        this.ai = _ai;
    }

    public override NodeState Evaluate()
    {
        Transform coverSpot = ai.GetBestCoverSpot();

        // g‚ğ‰B‚·Š‚ª–³‚¯‚ê‚Î¸”s
        if (coverSpot == null)
        {
            Debug.Log("GoToCoverNode / ‰B‚ê‚éŠ‚ª‚È‚¢");
            return NodeState.FAILURE;
        }

        ai.SetColor(Color.blue);
        float distance = Vector3.Distance(coverSpot.position, agent.transform.position);

        if(distance > 2.0f)
        {
            agent.isStopped = false;
            agent.SetDestination(coverSpot.position);

            Debug.Log("GoToCoverNode / ‰B‚ê‚éŠ‚Öo”­");
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;

            Debug.Log("GoToCoverNode / ‰B‚ê‚éŠ‚Ö“’…");
            return NodeState.SUCCESS;
        }
    }
}
