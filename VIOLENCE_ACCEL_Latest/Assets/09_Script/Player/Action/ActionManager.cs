//============================================================
// 攻撃など管理
//======================================================================
// 開発履歴
// 20220729:可用性向上のため再構築
// 20221010:武器が変な位置に生成される
//======================================================================
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VR.Players
{
    public class ActionManager
    {
        public enum Weapon
        {
            PRIMALY,
            SECONDALY,
            FREE,

            MAX
        }
        public Weapon HandState_L,HandState_R;

        GameObject PrimalyWeapon_L, PrimalyWeapon_R;
        GameObject SecondlyWeapon_L, SecondlyWeapon_R;


        // 初期
        public ActionManager(PlayerData _data, Transform _handL, XRBaseController _XRContrpllerL, Transform _handR, XRBaseController _XRContrpllerR, DirectionController _direction)
        {
            // 両腕に装備
            SetWeapon(_data, _handL, _XRContrpllerL, _handR, _XRContrpllerR, _direction);
        }

        
        // Weaponの生成
        public void SetWeapon(PlayerData _data, Transform _handL, XRBaseController _XRContrpllerL, Transform _handR, XRBaseController _XRContrpllerR, DirectionController _direction)
        {
            // 生成したものへ変更
            PrimalyWeapon_L = _data.Left_PrimaryWeapon.GetComponent<WeaponBase>().InstantWeapon(_handL, _XRContrpllerL, _direction);
            PrimalyWeapon_L.SetActive(true);
            PrimalyWeapon_R = _data.Right_PrimaryWeapon.GetComponent<WeaponBase>().InstantWeapon(_handR, _XRContrpllerR, _direction);
            PrimalyWeapon_R.SetActive(true);

            // 生成したものへ変更
            SecondlyWeapon_L = _data.Left_SecondaryWeapon.GetComponent<WeaponBase>().InstantWeapon(_handL, _XRContrpllerL, _direction);
            SecondlyWeapon_L.SetActive(false);
            SecondlyWeapon_R = _data.Right_SecondaryWeapon.GetComponent<WeaponBase>().InstantWeapon(_handR, _XRContrpllerR, _direction);
            SecondlyWeapon_R.SetActive(false);



        }

        // 武器の切り替え
        public void ChangeWeapon_L()
        {
            HandState_L++;
            if((int)HandState_L == 2) HandState_L = 0;

            switch ((int)HandState_L)
            {
                case 0:
                    PrimalyWeapon_L.SetActive(true);
                    SecondlyWeapon_L.SetActive(false);
                    break;
                case 1:
                    PrimalyWeapon_L.SetActive(false);
                    SecondlyWeapon_L.SetActive(true);
                    break;
                case 2:
                    Debug.Log("フリーハンド");
                    break;
                default:
                    Debug.Log("例外");
                    break;
            }
        }

        public void ChangeWeapon_R()
        {
            HandState_R++;
            if ((int)HandState_R == 2) HandState_R = 0;

            switch ((int)HandState_R)
            {
                case 0:
                    PrimalyWeapon_R.SetActive(true);
                    SecondlyWeapon_R.SetActive(false);
                    break;
                case 1:
                    PrimalyWeapon_R.SetActive(false);
                    SecondlyWeapon_R.SetActive(true);
                    break;
                case 2:
                    Debug.Log("フリーハンド");
                    break;
                default:
                    Debug.Log("例外");
                    break;
            }
        }

        // 第一スキル発動
        public string PrimalySkill_L()
        {
            string debugtext = "";
            switch ((int)HandState_L)
            {
                case 0:
                    debugtext = PrimalyWeapon_L.GetComponent<IWeaponAction>().PrimalySkill();
                    break;
                case 1:
                    debugtext = SecondlyWeapon_L.GetComponent<IWeaponAction>().PrimalySkill();
                    break;
                case 2:
                    debugtext = "フリー";
                    break;
                default:
                    debugtext = "例外" + HandState_L;
                    break;
            }

            return debugtext;

        }
        public void PrimalySkill_R()
        {
            switch ((int)HandState_R)
            {
                case 0:
                    PrimalyWeapon_R.GetComponent<IWeaponAction>().PrimalySkill();
                    break;
                case 1:
                    SecondlyWeapon_R.GetComponent<IWeaponAction>().PrimalySkill();
                    break;
                case 2:
                    Debug.Log("フリーハンド");
                    break;
                default:
                    Debug.Log("例外");
                    break;
            }
        }

        // 第二スキル発動
        public void SecondalySkill_L()
        {
            switch ((int)HandState_L)
            {
                case 0:
                    PrimalyWeapon_L.GetComponent<IWeaponAction>().SecondalySkill();
                    break;
                case 1:
                    SecondlyWeapon_L.GetComponent<IWeaponAction>().SecondalySkill();
                    break;
                case 2:
                    Debug.Log("フリーハンド");
                    break;
                default:
                    Debug.Log("例外");
                    break;
            }
        }
        public void SecondalySkill_R()
        {
            switch ((int)HandState_R)
            {
                case 0:
                    PrimalyWeapon_R.GetComponent<IWeaponAction>().SecondalySkill();
                    break;
                case 1:
                    SecondlyWeapon_R.GetComponent<IWeaponAction>().SecondalySkill();
                    break;
                case 2:
                    Debug.Log("フリーハンド");
                    break;
                default:
                    Debug.Log("例外");
                    break;
            }
        }
    }
}

