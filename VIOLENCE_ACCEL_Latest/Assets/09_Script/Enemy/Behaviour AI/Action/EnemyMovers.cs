using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovers : MonoBehaviour
{
    GameObject owner;
    public Transform eye;
    public Transform racer; // �󂯎��\��Ԃ�
    public Transform target;
    public Transform route;
    
    public float fSpeed = 0.1f;
    [SerializeField] bool circumvent = false;

    EnemyEye enemyEye;

    

    void Start()
    {
        owner = this.gameObject;
        target= racer; // �^�[�Q�b�g�͍ŏ��uracer�v�Ƃ���

        enemyEye = new EnemyEye();

        

    }


    void FixedUpdate()
    {


        switch (enemyEye.YAxisCheck(owner.transform, eye))
        {
            case 0:
                // ���[�T�[�ֈړ�
                owner.transform.LookAt(target);
                owner.transform.position += owner.transform.forward * fSpeed;
                //Debug.Log("�ǐ�");
                break;

            case 1:
                // ����
                owner.transform.LookAt(target);
                owner.transform.position += owner.transform.forward * fSpeed;
                //Debug.Log("����");
                break;

            case 2:
                // �I��
                route.position = eye.transform.forward * 1000;
                target = route;

                //�ڂ̌����𐳖ʂ֖߂�
                eye.transform.rotation = Quaternion.LookRotation(owner.transform.forward);
                //Debug.Log("�I��");

                break;
        }

        switch (enemyEye.XAxisCheck(owner.transform, eye))
        {
            case 0:
                // ���[�T�[�ֈړ�
                owner.transform.LookAt(target);
                owner.transform.position += owner.transform.forward * fSpeed;
                //Debug.Log("�ǐ�");
                break;

            case 1:
                // ����
                owner.transform.LookAt(target);
                owner.transform.position += owner.transform.forward * fSpeed;
                //Debug.Log("����");
                break;

            case 2:
                // �I��
                route.position = eye.transform.forward * 1000;
                target = route;

                //�ڂ̌����𐳖ʂ֖߂�
                eye.transform.rotation = Quaternion.LookRotation(owner.transform.forward);
                //Debug.Log("�I��");

                break;
        }
    }

    public void GetTarget(Transform _target)
    {
        target = _target;
        Debug.Log("���[�T�[����");
    }
}
