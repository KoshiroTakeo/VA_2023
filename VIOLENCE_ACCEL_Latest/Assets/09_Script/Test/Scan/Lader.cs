//=================================================================================================
// 壁検知用のレーダー
//=================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader : MonoBehaviour
{
    bool[] obstruct; // 壁の判定
    public int count;       // 方角
    int max;  // 方角の最大値
    Transform owner;
    [SerializeField] Collider sencer;

    Vector3 hitpos;
    Vector3 boundVec;

    //private void Start()
    //{
    //    max = 16;
    //    obstruct = new bool[max];
    //    owner = this.gameObject.transform;

    //    for(int i = 0; i < max; i++)
    //    {
    //        obstruct[i] = false;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    Debug.Log(Detective());
    //}

    //public bool Detective()
    //{
    //    if (count >= max) count = 0;

    //    owner.eulerAngles = new Vector3(0, (360 / max) * count, 0);
    //    //sencer.

    //    return obstruct[count++];
    //}

    void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("hit");
        float boundsPower = 10.0f;
        

        for (int i = 0; i < collision.contacts.Length; i++)
        {
            Debug.Log(collision.contacts[i].point + "/" + i);
            //boundVec = boundVec - collision.contacts[i].point;
        }

        Vector3 forceDir = boundsPower * boundVec.normalized;

        // 壁と反対に
        //this.gameObject.GetComponent<Rigidbody>().AddForce(forceDir, ForceMode.Impulse);
    }
}
