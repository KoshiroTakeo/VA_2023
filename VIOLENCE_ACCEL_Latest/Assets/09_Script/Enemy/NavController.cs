
using UnityEngine;
using UnityEngine.AI;
using VR.Enemys;

public class NavController 
{
    protected GameObject npc;
    protected NavMeshAgent agent;
    protected float fnpcSpeed;
    protected Transform PlayerPos;

    private int currentIndex = -1;
    private int nstateID = 0;
    private float fcorrection = 1.5f;

    public bool bApproach_To_Player = false;
    

    public NavController(GameObject _npc, NavMeshAgent _agent, EnemyData _enemyData, Transform _player)
    {
        npc = _npc;           
        agent = _agent;
        fnpcSpeed = _enemyData.fSpeed;
        PlayerPos = _player;
    }

    public void StateCheck(EnemyState.STATE _state)
    {
        if(!(nstateID == (int)_state))
        {
            switch (_state)
            {
                case EnemyState.STATE.IDLE:                                                                 
                    agent.isStopped = true;
                    break;

                case EnemyState.STATE.PATROL:
                    SetRoute();
                    agent.speed = fnpcSpeed;
                    agent.isStopped = false;
                    break;

                case EnemyState.STATE.PURSUE:
                    SetRoute();
                    agent.speed = fnpcSpeed * fcorrection;
                    agent.isStopped = false;
                    break;

                case EnemyState.STATE.RUNAWAY:
                    SetRoute();
                    agent.speed = fnpcSpeed;
                    agent.isStopped = false;
                    break;

                case EnemyState.STATE.ATTACK:
                    agent.isStopped = true;
                    break;

                case EnemyState.STATE.KNOCKOUT:
                    agent.isStopped = true;
                    break;

                case EnemyState.STATE.SLEEP:
                    agent.isStopped = true;
                    break;

                default:
                    break;
            }

            nstateID = (int)_state;
        }

        //エージェントの位置および現在の経路での目標地点の間の距離 ================================
        if (agent.remainingDistance < 1 )                                                                   
        {
            if (currentIndex >= EnemyWayPoint.Singleton.Checkpoints.Count - 1) currentIndex = 0;
            else currentIndex++;

            agent.SetDestination(EnemyWayPoint.Singleton.Checkpoints[currentIndex].transform.position);
        }
        else if(_state == EnemyState.STATE.PURSUE || _state == EnemyState.STATE.ATTACK)
        {
            if(bApproach_To_Player == true)
            {
                agent.SetDestination(PlayerPos.position);
            }
            
        }
        //=========================================================================================
        
    }



    // 周回地点を索敵 =============================================================================
    void SetRoute()
    {
        float lastDist = Mathf.Infinity;                                                          //最初は距離を無限とする(すべてのチェックポイントを探知するため)

        for (int i = 0; i < EnemyWayPoint.Singleton.Checkpoints.Count; i++)                     //チェックポイントの数だけ周る
        {
            GameObject thisWP = EnemyWayPoint.Singleton.Checkpoints[i];                         //目的地を読み込む
            float distance = Vector3.Distance(npc.transform.position, thisWP.transform.position); //目的地と自身の距離
            if (distance < lastDist)                                                              //たどり着いてなければ行う
            {
                currentIndex = i - 1;
                lastDist = distance;                                                              //無限の距離を次の目的地までとする
            }
        }
    }
    //=============================================================================================
}
