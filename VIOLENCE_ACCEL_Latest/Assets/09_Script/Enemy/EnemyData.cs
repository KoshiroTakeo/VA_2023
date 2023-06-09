//============================================================
// EnemyData.cs
//======================================================================
// 開発履歴
//
// 
// 
//
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Create EnemyData")]

public class EnemyData : ScriptableObject
{ 
    [Header("敵のステータス")]
    public int nLife = 10;
    public int nAttack = 10;
    public int nDefence = 10;
    public float fSpeed = 10;
    public float fBulletSpeed = 10;

    [Header("検知距離")]
    public float visDist = 40.0f;            //検知距離
    [Header("視野角")]
    public float visAngle = 60.0f;            //検知角
    [Header("攻撃距離")]
    public float shootDist = 30.0f;             //攻撃距離
    [Header("背後角度")]
    public float behideAngle = 20.0f;             //背後角度
    [Header("背後距離")]
    public float behideDist = 10.0f;             //背後角度
    [Header("攻撃間隔")]
    public float Atk_Interbal = 5.0f;             //攻撃間隔
    [Header("攻撃角度修正速度")]
    public float Atk_Rotation = 5.0f;             //攻撃角度修正速度
    [Header("待機状態へ戻る頻度")]
    public int BreakFrequency = 1000;             //攻撃角度修正速度


    [Header("被ダメージへの関心値")]
    public float Dangervalue = 0.07f; // 5秒間にHP％削れたら防御に入る
    [Header("ピンチになるHP％")]
    public float SeafValue = 0.3f; // 危険状態になるHP残量％

    public enum EnemyType
    {
        Normal_Axe,
        Normal_Gunner,

        Turret_FixedBase,
        Turret_CycleBase,


        MAX
    }

    
    public GameObject Bullet;
    public GameObject Explod;
}
