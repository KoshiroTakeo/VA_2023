using UnityEngine;
using UnityEngine.AI;
using VR.Enemys;

public class Knockout : EnemyState                                                                
{
    public Knockout(GameObject _npc,  Transform _player, EnemyData _enemyData)
        : base(_npc, _player, _enemyData)                                              
    {
        name = STATE.KNOCKOUT;                                                                
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
