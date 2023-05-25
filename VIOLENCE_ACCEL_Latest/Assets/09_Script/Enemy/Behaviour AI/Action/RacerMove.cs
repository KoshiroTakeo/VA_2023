using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerMove : MonoBehaviour
{
    Transform racer;
    Transform player;
    public Transform owner;
    Vector3 path;
    public float random = 40;
    public float fSpeed = 2;

    EnemyMovers enemyMovers;
    RaycastHit hit;
    Ray ray;

    void Start()
    {
        racer = this.gameObject.transform;
        player = GameObject.FindWithTag("Player").transform;
        path = player.position + new Vector3(Random.Range(-random, random), Random.Range(0.5f, random), Random.Range(-random, random));
    }

    void FixedUpdate()
    {
        // ���[�T�[�𓮂���点��
        racer.position = Vector3.Lerp(racer.position, path, fSpeed * Time.deltaTime);

        if (Vector3.Distance(owner.position, path) < 10.0f)
        {
            // player�̎�������̈ʒu��
            path = player.position + new Vector3(Random.Range(-random, random), Random.Range(0.5f, random), Random.Range(-random, random));

        }

        // �G�ɍŒZ������������
        racer.transform.LookAt(owner);
        ray = new Ray(racer.position, racer.forward); // �ڂ̈ʒu�ƕ���
        Debug.DrawRay(racer.position, racer.forward * 1000, Color.green);

        if(Physics.BoxCast(racer.position, owner.localScale * 0.5f, racer.forward * 1000, out hit))
        {
            if (!hit.collider.CompareTag("Enemy")) return;

            if(hit.collider.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<EnemyMovers>().GetTarget(racer);
            }
        }
            
        
    }
}
