//============================================================
// EnemyState.cs
//======================================================================
// 開発履歴
//
// 2022/05/31 author:竹尾　ポリモーフィズム確認
// 2022/06/01              MonoBehivior不要のため削除
// 2022/06/02              abstractにしてインスタンス不可にした
//
//======================================================================
using UnityEngine;
using UnityEngine.AI;

namespace VR.Enemys
{
    public abstract class EnemyState // ルールとしてインスタンス不可にしてみた（これ単体では起動しないため）
    {
        //行動状態の種類====================================================================
        public enum STATE // 列挙型
        {
            IDLE = 0,    // 待機
            PATROL = 1,  // 警備、徘徊
            PURSUE = 2,  // 追跡
            ATTACK = 3,  // 攻撃
            SLEEP = 4,   // 行動不能
            RUNAWAY = 5, // 逃走
            KNOCKOUT = 6,// 死亡時

            MAX
        };

        public STATE name; //行動状態確認用（書き換えられないようにしたい）
        //==================================================================================


        //イベント==========================================================================
        public enum EVENT
        {
            ENTER,  // 行動開始
            UPDATA, // 行動中
            EXIT    // 行動終了
        };

        protected EVENT stage;
        //==================================================================================

        // 遷移用 ==========================================================================
        protected GameObject npc;           //対象キャラ
        protected Transform player;         //プレイヤー座標
        protected EnemyData enemyData;      //視認距離などの情報

        protected EnemyState nextEnemyState;//次の行動

        //上の各行動状態には、これらの変数を当てはめる
        public EnemyState(GameObject _npc, Transform _player, EnemyData _enemyData)
        {
            npc = _npc;           //行動状態をとる対象()
            stage = EVENT.ENTER;  //状態開始時にとる行動
            player = _player;     //見ている対象、これに対して行動をとる
            enemyData = _enemyData;

        }
        //==================================================================================







        // 行動開始、実行中、終了時の"最後に"それぞれ呼び出す
        public virtual void Enter()
        {
            stage = EVENT.UPDATA; // ENTERだと止まる
        }
        public virtual void Updata()
        {
            stage = EVENT.UPDATA;
        }
        public virtual void Exit()
        {
            stage = EVENT.EXIT;
        }



        // これを呼び出す ********************************************
        public EnemyState Process()
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
        //*************************************************************




        //*******************************************************************************************************************************************************************
        //　敵とプレイヤーの位置による行動決定関数=====================================================================
        //*******************************************************************************************************************************************************************
        //プレイヤー感知(true/falseで返す) --------------------
        public bool CanSeePlayer()
        {
            Vector3 direction = player.position - npc.transform.position;  //directionでプレイヤーとの距離(位置)をとる
            float angle = Vector3.Angle(direction, npc.transform.forward); //2点間の位置の角度を返す

            if (direction.magnitude < enemyData.visDist && angle < enemyData.visAngle) { return true; }; //距離が近く、指定の角度内にも存在するとき

            return false;
        }
        //-----------------------------------------------------

        //プレイヤーへ攻撃する(true/falseで返す) --------------
        public bool CanAttackPlayer()
        {
            
            Vector3 direction = player.position - npc.transform.position;  //directionで自身との距離(位置)をとる
            if (direction.magnitude < enemyData.shootDist) { return true; }                     //↑の位置が射程内であれば

            return false;
        }
        //-----------------------------------------------------

        public void NextState(EnemyState enemyState)
        {
            nextEnemyState = enemyState;
            stage = EVENT.EXIT;
        }
        //==============================================================================================================
    }
}