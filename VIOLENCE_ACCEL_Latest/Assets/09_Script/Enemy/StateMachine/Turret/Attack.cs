using UnityEngine;
using UnityEngine.AI;
using VR.Enemys;

public class Attack : EnemyState                                                                
{
    public Attack(GameObject _npc, Transform _player, EnemyData _enemyData)
        : base(_npc, _player, _enemyData)                                              
    {
        name = STATE.ATTACK;                                                                
    }

    //virtual修飾子が付いたEnterを用いる
    public override void Enter()                                                          
    {
        base.Enter();                                                                     
    }

    //virtual修飾子が付いたUpdataを用いる
    public override void Updata()                                                        
    {
        if (enemyData.nLife <= 0) NextState(new Knockout(npc, player, enemyData));

        if (!CanAttackPlayer()) NextState(new Pursue(npc, player, enemyData));
    }

    //virtual修飾子が付いたExitを用いる
    public override void Exit()                                                            
    {
        base.Exit();
    }
}
