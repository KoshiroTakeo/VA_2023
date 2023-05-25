using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCoverAvaliableNode : Node
{
    private Cover[] avaliableCovers;
    private Transform target;
    private EnemyAI ai;

    public IsCoverAvaliableNode(Cover[] _avaliableCovers, Transform _target, EnemyAI _ai)
    {
        this.avaliableCovers = _avaliableCovers;
        this.target = _target;
        this.ai = _ai;
    }

    public override NodeState Evaluate()
    {
        Transform bestspot = FindBestCoverSpot();
        ai.SetBestCover(bestspot);
        return bestspot != null ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    
    private Transform FindBestCoverSpot()
    {
        float minAngle = 90;
        Transform bestspot = null;

        for(int i = 0; i < avaliableCovers.Length; i++)
        {
            Transform bestSpotInCover = BestFindSpotInCover(avaliableCovers[i], ref minAngle);
            if(bestSpotInCover != null)
            {
                bestspot = bestSpotInCover;
            }
        }

        return bestspot;
    }

    // 範囲内の
    private Transform BestFindSpotInCover(Cover _cover, ref float _minAngle)
    {
        if (ai.GetBestCoverSpot() != null)
        {
            if (CheckIfSpotIsValid(ai.GetBestCoverSpot()))
            {
                return ai.GetBestCoverSpot();
            }
        }

        Transform[] avaliableSpots = _cover.GetCoverSpots();
        Transform bestSpot = null;

        // 逃げ場所のどこに隠れるか
        for(int i = 0; i < avaliableCovers.Length; i++)
        {
            Vector3 direction = target.position - avaliableSpots[i].position;

            if(CheckIfSpotIsValid(avaliableSpots[i]))
            {
                // 壁側を向くように
                float angle = Vector3.Angle(avaliableSpots[i].forward, direction);

                if(angle < _minAngle)
                {
                    _minAngle = angle;
                    bestSpot = avaliableSpots[i];
                }
            }
        }

        return bestSpot;
    }

    // プレイヤーがいない逃げ場所か
    private bool CheckIfSpotIsValid(Transform _spot)
    {
        RaycastHit hit;
        Vector3 direction = target.position - _spot.position;

        if(Physics.Raycast(_spot.position, direction, out hit))
        {
            if(hit.collider.transform != target)
            {
                Debug.Log("IsCoverAvaliableNode / 逃げ場所確保");
                return true;
            }
        }

        Debug.Log("IsCoverAvaliableNode / 逃げ場所無し");
        return false;
    }
}
