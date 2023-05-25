//============================================================
// プレイヤーデータのスクリタブルデータ
//======================================================================
// 開発履歴
// 20220729:可用性向上のため再構築
//======================================================================
using UnityEngine;

namespace VR.Players
{
    // いずれテキストデータに
    [CreateAssetMenu(menuName = "Scriptable/New Create PlayerData")]
    public class PlayerData : ScriptableObject
    {
        // 各パラメータ
        public int nHP = 1000;
        public int nAttack = 100;
        public float fSpeed = 1;

        public int nShild = 200;
        

        // 装備
        public GameObject Left_PrimaryWeapon;
        public GameObject Left_SecondaryWeapon;
        public GameObject Right_PrimaryWeapon;
        public GameObject Right_SecondaryWeapon;
    }
}
