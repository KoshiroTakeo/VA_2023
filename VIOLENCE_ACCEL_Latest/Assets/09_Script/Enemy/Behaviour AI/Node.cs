using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum NodeState
{
    RUNNING, // é¿çsíÜ
    SUCCESS, // äÆóπ
    FAILURE  // é∏îs
}
// íäè€âª
public abstract class Node 
{
    protected NodeState _nodeState;

    public NodeState nodeState { get { return _nodeState; } }

    public abstract NodeState Evaluate();
}


