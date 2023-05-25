using UnityEngine;
using UnityEngine.AI;
using VR.Enemys;

public class Idle : EnemyState                                                                
{
    public Idle(GameObject _npc, Transform _player, EnemyData _enemyData)
        : base(_npc,_player, _enemyData)                                              
    {
        name = STATE.IDLE;                                                                
    }

    public override void Enter()                                                          
    {
        base.Enter();                                                                     
    }

    public override void Updata()
    {
        NextState(new Patrol(npc, player, enemyData));
    }

    public override void Exit()                                                           
    {
        base.Exit();
    }
}
