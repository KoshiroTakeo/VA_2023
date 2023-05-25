using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeNode : Node
{
    private float range;
    private Transform target;
    private Transform origin;

    public RangeNode(float _range, Transform _target, Transform _origin)
    {
        this.range = _range;
        this.target = _target;
        this.origin = _origin;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(target.position, origin.position);

        if(distance <= range)
        {
            Debug.Log("RangeNode / Player‚Ö“ž’B : " + range);
        }
        
        return distance <= range ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
