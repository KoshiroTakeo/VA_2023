//=================================================================================================
// �ǌ��m�p�̃��[�_�[
//=================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader : MonoBehaviour
{
    bool[] obstruct; // �ǂ̔���
    public int count;       // ���p
    int max;  // ���p�̍ő�l
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

        // �ǂƔ��΂�
        //this.gameObject.GetComponent<Rigidbody>().AddForce(forceDir, ForceMode.Impulse);
    }
}
