//===============================================
// ŽŸ‚Ì–Ú“I’n‚Í’m‚Á‚Ä‚¢‚é‚©
//===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR.Enemys;

public class IshavePath : Node
{
    EliteEnemy owner;
    Transform player;

    Transform racer;
    float fSpeed;

    public float randomRange = 40.0f;

    public IshavePath(EliteEnemy _owner, Transform _player, Transform _racer, float _speed)
    {
        owner = _owner;
        player = _player;
        racer = _racer;
        fSpeed = (_speed * 1.3f);
    }

    public override NodeState Evaluate()
    {
        racer.position = Vector3.Lerp(racer.position, owner.path, fSpeed * Time.deltaTime);


        
        if (Vector3.Distance(owner.transform.position, owner.path) < 10.0f)
        {
            
            owner.path = player.position + new Vector3(Random.Range(-randomRange, randomRange), 0, Random.Range(-randomRange, randomRange));
            
        }

        return NodeState.SUCCESS;
    }
}
