using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCovereNode : Node
{
    private Transform target;
    private Transform origin;

    public IsCovereNode(Transform _target, Transform _origin)
    {
        this.target = _target;
        this.origin = _origin;
    }

    public override NodeState Evaluate()
    {
        RaycastHit hit;

        if(Physics.Raycast(origin.position, target.position - origin.position, out hit))
        {
            // 標的（プレイヤー）以外
            if(hit.collider.transform != target)
            {
                Debug.Log("IsCovereNode / ターゲットから逃げている");
                return NodeState.SUCCESS;
            }
        }

        Debug.Log("IsCovereNode / ターゲット発見、逃げる");
        return NodeState.FAILURE;
    }
}
