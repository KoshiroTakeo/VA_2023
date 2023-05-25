//============================================================
// EnemyWeapon.cs
//======================================================================
// 開発履歴
//
// 2022/12/11 敵の武器、攻撃。プレイヤーのウェポンデータを流用
//
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    // 武器種
    public enum WeaponStyle
    {
        GUN = 0,
        SWORD = 1,
        SHIRD = 2,
        FREE = 3,
        MAX = 4
    };
    public WeaponStyle Style;

    [SerializeField] WeaponData weaponData; // 武器データ

    // 必要ステータス
    [SerializeField] protected float fAttack; // 威力
    [SerializeField] protected float fSpeed;  // 弾速、身体強化
    [SerializeField] protected float fRecast_Primaly, fRecast_Secondly; //リロード時間
    [SerializeField] protected bool bStanby_Primaly, bStanby_Secondly;  //スキル準備完了

    public GameObject PrimaryBullet;
    protected GameObject SecondlyBullet;

    [SerializeField] protected WaitForSeconds WTS_SetTime_Primaly, WTS_SetTime_Secondly;



    public GameObject InstantWeapon(Transform _handPos)
    {
        // プレハブを直接、親を変えるのは出来ないため
        GameObject instantWeapon = Instantiate(this.gameObject);
        instantWeapon.transform.parent = _handPos.transform;
        instantWeapon.transform.position = _handPos.transform.position;

        SetParameter();

        return instantWeapon;
    }

    // 武器データ反映
    public void SetParameter()
    {

        Style = (WeaponStyle)weaponData.Style;
        fAttack = weaponData.fAttack;
        fSpeed = weaponData.fBulletSpeed;
        fRecast_Primaly = weaponData.fRecast_Primaly;
        fRecast_Secondly = weaponData.fRecast_Secondly;
        bStanby_Primaly = bStanby_Secondly = false;
        WTS_SetTime_Primaly = new WaitForSeconds(fRecast_Primaly);
        WTS_SetTime_Secondly = new WaitForSeconds(fRecast_Secondly);

        if (!(weaponData.PrimaryBullet == null)) PrimaryBullet = weaponData.PrimaryBullet;
        if (!(weaponData.SecondlyBullet == null)) SecondlyBullet = weaponData.SecondlyBullet;

        Debug.Log(this.gameObject.name + "セット");
    }


    protected IEnumerator Recasttime_Primaly(float _recasttime)
    {
        WaitForSeconds set = new WaitForSeconds(_recasttime);
        bStanby_Primaly = true;
        yield return set;
        bStanby_Primaly = false;
        Debug.Log("使用可");
    }

    protected IEnumerator Recasttime_Secondly(float _recasttime)
    {
        WaitForSeconds set = new WaitForSeconds(_recasttime);
        bStanby_Secondly = true;
        yield return set;
        bStanby_Secondly = false;
        Debug.Log("使用可");
    }

   
}
