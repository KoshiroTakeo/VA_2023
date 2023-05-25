using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfenceAction : Node
{


    GameObject owner;
    Transform target; // æ‚ğ‘–‚éƒŒ[ƒT[
    float fSpeed;
    
    public OfenceAction(GameObject _owner, Transform _target, float _speed)
    {
        owner = _owner;
        target = _target;
        fSpeed = _speed;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("UŒ‚’†");

        owner.transform.LookAt(target);
        owner.transform.position = Vector3.Lerp(owner.transform.position, target.position, fSpeed * Time.deltaTime);

       

        return NodeState.RUNNING;
    }
}
