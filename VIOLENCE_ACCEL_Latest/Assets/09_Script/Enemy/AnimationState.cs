using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR.Enemys;

public class AnimationState 
{
    public enum ANIME
    {
        IDLE = 0,
        WALK = 1,
        RUN = 2,
        SLEEP = 3,
        ATTACK_1 = 4,
        ATTACK_2 = 5,
        ATTACK_3 = 6,
        DOWN = 7,

        MAX
    };

    public ANIME name;

    private int nstateID = 0;
    private Animator anim;

    public AnimationState(Animator _anim)
    {
        anim = _anim;
    }

    public void StateCheck(EnemyState.STATE _state)
    {
        if (!(nstateID == (int)_state))
        {
            anim.SetBool(name.ToString(), false);
            switch (_state)
            {
                case EnemyState.STATE.IDLE:
                    name = ANIME.IDLE;
                    anim.SetBool(name.ToString(), true);
                    break;

                case EnemyState.STATE.PATROL:
                    name = ANIME.WALK;
                    anim.SetBool(name.ToString(), true);
                    break;

                case EnemyState.STATE.PURSUE:
                    name = ANIME.RUN;
                    anim.SetBool(name.ToString(), true);
                    break;

                case EnemyState.STATE.RUNAWAY:
                    name = ANIME.RUN;
                    anim.SetBool(name.ToString(), true);
                    break;

                case EnemyState.STATE.ATTACK:
                    name = ANIME.ATTACK_1;
                    anim.SetBool(name.ToString(), true);
                    break;

                case EnemyState.STATE.KNOCKOUT:
                    name = ANIME.DOWN;
                    anim.SetBool(name.ToString(), true);
                    break;

                case EnemyState.STATE.SLEEP:
                    name = ANIME.SLEEP;
                    anim.SetBool(name.ToString(), true);
                    break;

                default:
                    break;
            }
            nstateID = (int)_state;
        }
    }
}
