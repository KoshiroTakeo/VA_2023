//============================================================
// Controller.cs
//======================================================================
// 開発履歴
//
// 2022/05/01 author 竹尾：制作、MoveManagerに必要
// 
//
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnchor : MonoBehaviour
{
    public GameObject Centereye; // カメラ座標取得
    public GameObject PlayerObj; // プレイヤー自体


    public void SetAnchor(GameObject _centereye, GameObject _player)
    {
        Centereye = _centereye;
        PlayerObj = _player;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0,0,0);
        this.transform.rotation = new Quaternion();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Updateでnewを使わない方法　＞　if切ってその方向に言ったらtransform.position += transform.forwardするとか試す（重くなってきたら試す）
        this.transform.position = Centereye.transform.localPosition;
        this.transform.rotation = PlayerObj.transform.rotation;
    }
}
