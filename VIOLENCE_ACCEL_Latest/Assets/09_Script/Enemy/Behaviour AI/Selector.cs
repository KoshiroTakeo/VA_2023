//*********************************************************
// FAILUREなら次のノードへ進む、SUCCESSなら終了
//*********************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    protected List<Node> nodes = new List<Node>();

    // 選択する行動内容が入ったNodeを格納
    public Selector(List<Node> _nodes)
    {
        this.nodes = _nodes;
    }

    // NodeState（行動状況）を返す
    public override NodeState Evaluate()
    {
        // Nodeをすべて評価
        foreach (var node in nodes)
        {
            // 格納したNodeから評価
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    return _nodeState;

                case NodeState.SUCCESS:
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;

                case NodeState.FAILURE:
                    break;

                default:
                    break;
            }
        }

        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
}
