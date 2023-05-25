//============================================================
// WeaponBase.cs
//======================================================================
// 開発履歴
//
// 2022/10/11 
//
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using VR.Players;


public class WeaponBase : MonoBehaviour
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
    [SerializeField] protected DirectionController Direction; // 演出系

    // 必要ステータス
    [SerializeField] protected float fAttack; // 威力
    [SerializeField] protected float fBulletSpeed;  // 弾速、身体強化
    [SerializeField] protected float fRecast_Primaly, fRecast_Secondly; //リロード時間
    [SerializeField] protected bool bStanby_Primaly, bStanby_Secondly;  //スキル準備完了 
                                                          
    protected XRBaseController XRController;

    public GameObject PrimaryBullet;
    public GameObject SecondlyBullet;

    public GameObject PrimalySkill_Particle;
    public GameObject SecondlySkill_Particle;

    [SerializeField] protected WaitForSeconds WTS_SetTime_Primaly, WTS_SetTime_Secondly;

   

    public GameObject InstantWeapon(Transform _handPos, XRBaseController _XRContrpller, DirectionController _direction)
    {
        // プレハブを直接、親を変えるのは出来ないため
        GameObject instantWeapon = Instantiate(this.gameObject);
        instantWeapon.transform.parent =  _handPos.transform;
        instantWeapon.transform.position = _handPos.transform.position;

        XRController = _XRContrpller;

        Direction = _direction;
        
        SetParameter();
       

        return instantWeapon;
    }

    // 武器データ反映
    void SetParameter()
    {
        
        Style = (WeaponStyle)weaponData.Style;
        fAttack = weaponData.fAttack;
        fBulletSpeed = weaponData.fBulletSpeed;
        fRecast_Primaly = weaponData.fRecast_Primaly;
        fRecast_Secondly = weaponData.fRecast_Secondly;

        PrimaryBullet = weaponData.PrimaryBullet;
        SecondlyBullet = weaponData.SecondlyBullet;
        PrimalySkill_Particle = weaponData.PrimaryEffect;
        SecondlySkill_Particle = weaponData.SecondlyEffect;

        bStanby_Primaly = bStanby_Secondly = false;
        WTS_SetTime_Primaly = new WaitForSeconds(fRecast_Primaly);
        WTS_SetTime_Secondly = new WaitForSeconds(fRecast_Secondly);



        Debug.LogWarning("データを変更した際は手動で入れなおさないと反映されないかも");
    }

    
    protected IEnumerator Recasttime_Primaly(float _recasttime)
    {
        WaitForSeconds set = new WaitForSeconds(_recasttime);
        bStanby_Primaly = true;
        yield return set;
        bStanby_Primaly = false;

    }

    protected IEnumerator Recasttime_Secondly(float _recasttime)
    {
        WaitForSeconds set = new WaitForSeconds(_recasttime);
        bStanby_Secondly = true;
        yield return set;
        bStanby_Secondly = false;
        //Debug.Log("使用可");
    }

    public string OnHaptic(float _amplitube, float _duration)
    {
        if (XRController == null) return "Out";
        XRController.SendHapticImpulse(_amplitube, _duration);
        Debug.Log("振動しねぇよ");
        return null;
    }
}
