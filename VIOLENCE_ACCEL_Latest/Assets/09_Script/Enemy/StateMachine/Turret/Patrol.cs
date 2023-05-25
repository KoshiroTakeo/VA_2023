using UnityEngine;
using UnityEngine.AI;
using VR.Enemys;

public class Patrol : EnemyState                                                                
{
    public Patrol(GameObject _npc, Transform _player, EnemyData _enemyData)
        : base(_npc, _player, _enemyData)                                             
    {
        name = STATE.PATROL;                                                                
    }

    public override void Enter()                                                          
    {
        base.Enter();                                                                     
    }

    public override void Updata()                                                         
    {
        if (enemyData.nLife <= 0) NextState(new Knockout(npc,  player, enemyData));

        if (CanSeePlayer()) NextState(new Pursue(npc,  player, enemyData));
    }
    
    public override void Exit()                                                            
    {
        base.Exit();
    }
}
