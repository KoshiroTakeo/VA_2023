using UnityEngine;
using UnityEngine.AI;
using VR.Enemys;
public class Runaway : EnemyState                                                                
{
    public Runaway(GameObject _npc,  Transform _player, EnemyData _enemyData)
        : base(_npc,  _player, _enemyData)                                              
    {
        name = STATE.IDLE;                                                                
    }


    
    public override void Enter()                                                          
    {
        base.Enter();                                                                     
    }



    public override void Updata()                                                         
    {

    }


    public override void Exit()                                                            
    {
        base.Exit();
    }
}