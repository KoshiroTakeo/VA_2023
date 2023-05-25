using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/New Create WeaponData")]
public class WeaponData : ScriptableObject
{
    public enum WeaponStyle
    {
        GUN = 0,
        SWORD = 1,
        SHIRD = 2,
        FREE = 3,
        MAX = 4
    };
    public WeaponStyle Style;

    // 各パラメータ
    public float fAttack = 10;
    public float fBulletSpeed = 1;
    public float fRecast_Primaly = 0.3f;
    public float fRecast_Secondly = 5.0f; 
    
    // 生成させる弾
    public GameObject PrimaryBullet;
    public GameObject SecondlyBullet;  
    
    // 生成させるエフェクト
    public GameObject PrimaryEffect;
    public GameObject SecondlyEffect;

}
