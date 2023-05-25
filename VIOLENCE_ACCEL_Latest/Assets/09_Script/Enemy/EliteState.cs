using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR.Enemys
{
    public abstract class EliteState 
    {
        public enum STATE
        {
            OFFENCE,
            DEFENCE,

            MAX
        };
        public STATE name;

        public enum EVENT
        {
            ENTER,  // 行動開始
            UPDATA, // 行動中
            EXIT    // 行動終了
        };
        protected EVENT stage;



        protected int value;
        protected EliteState nextEnemyState;

        public EliteState(int _value)
        {
            value = _value;

            stage = EVENT.ENTER;
        }



        public virtual void Enter()
        {
            stage = EVENT.UPDATA;
        }
        public virtual void Updata()
        {
            stage = EVENT.UPDATA;
        }
        public virtual void Exit()
        {
            stage = EVENT.EXIT;
        }

        public EliteState Process()
        {
            //stateから読み取る
            if (stage == EVENT.ENTER) Enter();  //Enterの処理を行う

            if (stage == EVENT.UPDATA) Updata(); //Updataの処理を行う

            if (stage == EVENT.EXIT)      //Exitの処理を行う
            {
                Exit();
                return nextEnemyState; //次の行動に移す
            }

            return this; // EnemyStateを返す
        }



        // 攻守の評価
        public STATE EvaluationState()
        {
            return STATE.OFFENCE;
        }



        public void NextState(EliteState enemyState)
        {
            nextEnemyState = enemyState;
            stage = EVENT.EXIT;
        }
    }
}

