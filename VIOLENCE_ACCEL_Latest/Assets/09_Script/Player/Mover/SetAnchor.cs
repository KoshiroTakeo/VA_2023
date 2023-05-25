//============================================================
// アンカー
//======================================================================
// 開発履歴
// 20220729:可用性向上のため再構築
//======================================================================
using UnityEngine;

namespace VR.Players
{
    public class SetAnchor : MonoBehaviour
    {
        GameObject Centereye; // カメラ座標取得
        GameObject PlayerObj; // プレイヤー自体

        public GameObject AnchorObject;

        public SetAnchor(GameObject _centereye, GameObject _player)
        {
            GameObject obj = new GameObject("AnchorObject");

            Centereye = _centereye;
            PlayerObj = _player;

            obj.transform.position = new Vector3(0, 3, 0);
            obj.transform.rotation = new Quaternion();

            AnchorObject = obj;
        }

        void Update()
        {
            this.transform.position = new Vector3(Centereye.transform.localPosition.x, 30, Centereye.transform.localPosition.z);
            this.transform.rotation = PlayerObj.transform.rotation;
        }
    }
}

