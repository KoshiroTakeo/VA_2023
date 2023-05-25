using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventor : Node
{
    protected Node node;

    public Inventor(Node _node)
    {
        this.node = _node;
    }

    public override NodeState Evaluate()
    {
        switch(node.Evaluate())
        {
            case NodeState.RUNNING:
                _nodeState = NodeState.RUNNING;
                return _nodeState;

            case NodeState.SUCCESS:
                _nodeState = NodeState.SUCCESS;
                return _nodeState;

            case NodeState.FAILURE:
                _nodeState = NodeState.FAILURE;
                break;

            default:
                break;
        }

        return _nodeState;
    }
}
