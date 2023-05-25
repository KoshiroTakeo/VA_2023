//===============================================
//　武器のリキャストは終えているか
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IsWeaponReady : Node
{
    public override NodeState Evaluate()
    {
        return NodeState.SUCCESS;
    }
}
