using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovers : MonoBehaviour
{
    GameObject owner;
    public Transform eye;
    public Transform racer; // 受け取り可能状態に
    public Transform target;
    public Transform route;
    
    public float fSpeed = 0.1f;
    [SerializeField] bool circumvent = false;

    EnemyEye enemyEye;

    

    void Start()
    {
        owner = this.gameObject;
        target= racer; // ターゲットは最初「racer」とする

        enemyEye = new EnemyEye();

        

    }


    void FixedUpdate()
    {


        switch (enemyEye.YAxisCheck(owner.transform, eye))
        {
            case 0:
                // レーサーへ移動
                owner.transform.LookAt(target);
                owner.transform.position += owner.transform.forward * fSpeed;
                //Debug.Log("追跡");
                break;

            case 1:
                // 減速
                owner.transform.LookAt(target);
                owner.transform.position += owner.transform.forward * fSpeed;
                //Debug.Log("減速");
                break;

            case 2:
                // 迂回
                route.position = eye.transform.forward * 1000;
                target = route;

                //目の向きを正面へ戻す
                eye.transform.rotation = Quaternion.LookRotation(owner.transform.forward);
                //Debug.Log("迂回");

                break;
        }

        switch (enemyEye.XAxisCheck(owner.transform, eye))
        {
            case 0:
                // レーサーへ移動
                owner.transform.LookAt(target);
                owner.transform.position += owner.transform.forward * fSpeed;
                //Debug.Log("追跡");
                break;

            case 1:
                // 減速
                owner.transform.LookAt(target);
                owner.transform.position += owner.transform.forward * fSpeed;
                //Debug.Log("減速");
                break;

            case 2:
                // 迂回
                route.position = eye.transform.forward * 1000;
                target = route;

                //目の向きを正面へ戻す
                eye.transform.rotation = Quaternion.LookRotation(owner.transform.forward);
                //Debug.Log("迂回");

                break;
        }
    }

    public void GetTarget(Transform _target)
    {
        target = _target;
        Debug.Log("レーサー発見");
    }
}
