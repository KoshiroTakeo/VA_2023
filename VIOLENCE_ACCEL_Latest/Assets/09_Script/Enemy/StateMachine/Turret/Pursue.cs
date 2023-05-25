using UnityEngine;
using UnityEngine.AI;
using VR.Enemys;

public class Pursue : EnemyState                                                                
{
    public Pursue(GameObject _npc,Transform _player, EnemyData _enemyData)
        : base(_npc, _player, _enemyData)                                              
    {
        name = STATE.PURSUE;                                                                
    }

    public override void Enter()                                                          
    {
        base.Enter();                                                                     
    }

    public override void Updata()                                                         
    {
        if (enemyData.nLife <= 0) NextState(new Knockout(npc, player, enemyData));

        
        if (CanAttackPlayer()) NextState(new Attack(npc,  player, enemyData));
        else if (!CanSeePlayer()) NextState(new Idle(npc,  player, enemyData));
        
    }

    public override void Exit()                                                            
    {
        base.Exit();
    }
}
