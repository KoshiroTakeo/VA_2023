//*********************************************************
// SUCCESSを返したら次のノードへ進む、FAILUREなら以降は読まない
//*********************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();

    // 選択する行動内容が入ったNodeを格納
    public Sequence(List<Node> _nodes)
    {
        this.nodes = _nodes;
    }

    // NodeState（行動状況）を返す
    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false;

        foreach(var node in nodes)
        {
            // 格納したNodeから評価
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    isAnyNodeRunning = true;
                    break;

                case NodeState.SUCCESS: // falseのまま出る
                    break;

                case NodeState.FAILURE: // 失敗したならすぐ出る
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;

                default:
                    break;
            }
        }

        // isAnyNodeRunning がTrueかfalseでStateが変化
        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return _nodeState;
    }
}
