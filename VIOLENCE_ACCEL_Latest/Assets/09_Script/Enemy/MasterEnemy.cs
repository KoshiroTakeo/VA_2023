//============================================================
// シーン上の敵
//======================================================================
// 開発履歴
// 20221107:情報を受け渡すだけ
// 20221108:パラメーター管理
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace VR.Enemys
{
    public class MasterEnemy : MonoBehaviour, IDamageble<float>
    {
        // 必要コンポーネント
        protected EnemyState CurrentState;
        // Behaviourクラスをここに
        protected NavMeshAgent NavMesh;
        protected NavController Move;
        protected Animator Anime;
        protected AnimationState Motion;
        protected ActionTrigger Trigger;
        protected DirectionController Direction;

        // UI関係
        [SerializeField] protected GameObject BarPrefab;
        protected LifeBar BarStatus;

        // Enemyのパラメータデータ
        [SerializeField] EnemyData Data;
        [SerializeField] Transform UIPopPos;
        protected EnemyParameter Parameter;

        // プレイヤー情報
        protected Transform PlayerPos;


        protected string SetUP()
        {
            PlayerPos = GameObject.FindWithTag("Player").transform;
            NavMesh = GetComponent<NavMeshAgent>();
            Anime = GetComponent<Animator>();
            Direction = GameObject.FindWithTag("Manager").GetComponent<DirectionController>();

            Parameter = new EnemyParameter(Data);
            CurrentState = new Idle(this.gameObject,PlayerPos, Data);
            Move = new NavController(this.gameObject, NavMesh, Data, PlayerPos);
            Motion = new AnimationState(Anime);


            // アニメーションイベントで拾えるようにコンポーネント
            //Trigger = this.gameObject.AddComponent<ActionTrigger>();
            //Trigger = new AttackTrigger();

            // HPバーの情報を取得
            UIPopPos = this.gameObject.transform;
            BarPrefab = Instantiate(BarPrefab, UIPopPos);
            BarStatus = BarPrefab.GetComponent<LifeBar>();
            BarStatus.SetLifeBar(this.gameObject, Parameter.nHP);

            return this.gameObject.name + "[SetUp Complete]";
        }

        

        public void AddDamage(float _damage)
        {
            Debug.Log(_damage);
            Parameter.nHP = Parameter.nHP - (int)_damage;
            BarStatus.UpdataLife(Parameter.nHP);
            Direction.soundManager.PlaySE(SEData.Tag.DamageHit, this.gameObject, 1f);
        }

        protected void Death()
        {
            
            Instantiate(Parameter.Explod);
            Destroy(this.gameObject);
            
        }

        public void AnimCall_Shot()
        {
            Debug.Log("弾丸発射");
        }

        public void AnimCall_Attack()
        {
            Debug.Log("肉弾攻撃");
        }
    }
}
