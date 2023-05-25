//============================================================
// プレイヤーの能力値
//======================================================================
// 開発履歴
// 20220729:可用性向上のため再構築
//======================================================================
using UnityEngine;

namespace VR.Players
{
    public class PlayerParameter 
    {
        // 各パラメータ
        public int nHP = 1000;
        int nMaxHP;
        public int nAttack = 100;
        public float fSpeed = 1;
        public int nShild = 200;
        int nMaxShild;


        // 装備
        public GameObject Left_PrimaryWeapon;
        public GameObject Left_SecondaryWeapon;
        public GameObject Right_PrimaryWeapon;
        public GameObject Right_SecondaryWeapon;

        public PlayerParameter(PlayerData _data)
        {
            nMaxHP = nHP = _data.nHP;
            nAttack = _data.nAttack;
            fSpeed = _data.fSpeed;
            nMaxShild = nShild = _data.nShild;

            nShild = 0;
        }

        public float CurrentHPValue()
        {
            float value;
            value = (float)nHP / (float)nMaxHP;

            return value;
        }

        public void RecoverShild(float _speedvalue)
        {
            nShild += (int)(_speedvalue * 0.2);

            if (nShild >= nMaxShild) nShild = nMaxShild;

        }

        public float CurrentShild()
        {
            float value;
            value = (float)nShild / (float)nMaxShild;

            return value;
        }

        public void call()
        {
            Debug.Log("能力セット");
        }
    }
}

