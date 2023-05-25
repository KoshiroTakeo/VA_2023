//============================================================
// ���̈ړ�����
//======================================================================
// �J������
// 20220729:�p������̂��ߍč\�z
//======================================================================
using UnityEngine;

namespace VR.Players
{
    public class HoverMover 
    {
        // �K�v�Ȃ���
        public float fAccelCircleSize = 0.02f;
        public float fSquatHeight = 0.9f; // �����\�Ƃ���
        public float fJumpHeight = 1.6f; // �����\�Ƃ���
        public float fstoptime = 0.5f;
        public float fbreakvalue = 1f;
        public float fupvalue = 1f;
        public float fGravity = -0.8f;

        bool bThrust_L = false, bThrustR = false;
        int nFual = 1000;
        int nJetPower = 1000;
        bool bFlyReady = false;
        bool bFly = false;
        int nFlyTime = 0;
        int nReadyTime = 0;
        
        public void HeadInclinationMove(CharacterController _character ,Vector3 _anchor, Vector3 _initirizepos, float _speed)
        {
            Vector3 vector = _anchor - _initirizepos;
            Vector3 direction = new Vector3();
            bool bStop = true;
            float faccel;

            // ���E���x�␳�l
            float fAnchorX = vector.normalized.x;
            float fAnchorZ = vector.normalized.z;
            float fAnchorY = vector.y * fGravity;



            // ��~�͈͊O�ɏo���Ƃ�����o��
            if ((fAnchorZ > fAccelCircleSize || -fAccelCircleSize > fAnchorZ))
            {
                direction.z = fAnchorZ / fAccelCircleSize;
                bStop = true;
            }

            if ((fAnchorX > fAccelCircleSize || -fAccelCircleSize > fAnchorX))
            {
                direction.x = fAnchorX / fAccelCircleSize;
                bStop = true;
            }

            direction.y = fAnchorY;


            // ���Ⴊ�݃u���[�L
            if (vector.y < fSquatHeight)
            {
                fbreakvalue = fbreakvalue * ((vector.y / fSquatHeight));

                bFlyReady = true;
                nReadyTime = 0;
            }
            else
            {
                fbreakvalue = 1;
            }

            if(bFly == true && nFlyTime < 60)
            {
                direction.y = _speed * fupvalue * (nFlyTime * 4);
                nFlyTime++;
            }
            

            // 30�t���[���ԃW�����v�̗P�\
            if (nReadyTime >= 30) bFlyReady = false;

            //// ���
            //if (bFly == true)
            //{
            //    //�ŏ����ڂ͐����悭��т���
            //    if (nFlyTime >= 10)
            //    {
            //        nFlyTime--;
            //    }


            //    direction.y = _speed * fupvalue * (nFlyTime / 2);
            //}
            //else
            //{
            //    direction.y = fAnchorY;
            //    nFlyTime++;
            //    if (nFlyTime >= 120)
            //    {
            //        nFlyTime = 120;
            //    }
            //}


            // �u���[�L�W����������
            faccel = _speed * fbreakvalue;

            // �ړ�����
            if (!bStop)
            {
                _character.Move(direction * Time.fixedDeltaTime * faccel);
            }
            else
            {
                _character.Move(direction * Time.fixedDeltaTime * (faccel / fstoptime));
            }

            
        }

        public void Thruster_L(bool _on)
        {
            bThrust_L = _on;
            
        }
        public void Thruster_R(bool _on)
        {
            bThrustR = _on;
           
        }

        int ThrusterPower()
        {
            int power = 0;

            power = nJetPower;
            nJetPower = nJetPower - 2;

            return power;
        }

        public void ThrusterControll(Rigidbody _rb, Transform _owner, float _fspeed)
        {
            //Debug.Log(nFual);

            //if(nFual > 0)
            //{
            //    if (bThrustR == true && bThrust_L == true)
            //    {
                    
            //        _rb.AddForce(_owner.up * _fspeed * ThrusterPower(), ForceMode.Impulse);
            //        nFual--;
            //    }
            //    else if (bThrust_L == true)
            //    {
                    
            //        _rb.AddForce(-_owner.right * _fspeed * ThrusterPower(), ForceMode.Impulse);
            //        nFual--;
            //    }
            //    else if (bThrustR == true)
            //    {
                   
            //        _rb.AddForce(_owner.right * _fspeed * ThrusterPower(), ForceMode.Impulse);
            //        nFual--;
            //    }
            //    else
            //    {
            //        //nJetPower++;
            //    }
            //}
            
            //if (nFual < 1000 && (bThrustR == bThrust_L == false))
            //{
            //    nFual++;
            //}
            //else
            //{
            //    nFual = 1000;
            //}
        }
    }
}
