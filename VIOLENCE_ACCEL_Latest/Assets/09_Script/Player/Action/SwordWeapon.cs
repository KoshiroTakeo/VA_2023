using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordWeapon : WeaponBase, IWeaponAction
{
	SwordCollider Sword;
	GameObject AttackPoint = null; // �����蔻��I�u�W�F�N�g
	float fAddForce_Damage = 2.0f; // ���̊�{�З�


	// �����x���v�Z�ɕK�v�ȕ��� =====================
	private Coroutine routine;
	private Vector3[] velocitySamples; // �L�^����l����

	private int sampleCount;
	private float fOnAttackVelocity = 1100; // �ǂꂾ���̋����ŐU�����甽�����邩
	//===========================================



	private void Start()
	{
		velocitySamples = new Vector3[5];
		BeginEstimatingVelocity(); // �R���[�`�����񂵎n�߂�

		AttackPoint = transform.Find("AttackPoint").gameObject;
		Sword = AttackPoint.GetComponent<SwordCollider>();
		Sword.SetSwordWeapon(this); // ���g��o�^
	}

    private void FixedUpdate()
	{
		if (this.gameObject.activeSelf == true)
		{
			// �����x�v�Z���s��
			SlashAttack();
		}
		else if (this.gameObject.activeSelf == false)
		{
			// ���̂����蔻�������
			AttackPoint.SetActive(false);
		}
	}



	void SlashAttack()
	{
		if (GetAccelerationEstimate().y > fOnAttackVelocity || GetAccelerationEstimate().y < -fOnAttackVelocity)
		{
			AttackPoint.SetActive(true);
	    }
		else
		{
			AttackPoint.SetActive(false);
		}
	}

	public string PrimalySkill()
	{
		string debugtext = "now charge Sword";

		if (bStanby_Primaly == true) return debugtext;
		debugtext = OnHaptic(0.3f, 0.4f);
		StartCoroutine(Recasttime_Primaly(fRecast_Primaly));

		// �\�͔���
		PowerAttack();

		return debugtext;
	}

	public void SecondalySkill()
	{
		if (bStanby_Secondly == true) return;
		StartCoroutine(Recasttime_Secondly(fRecast_Secondly));

		// �\�͔���
		PhysicalUP();
	}

	// PrimarySkill =======================================
	void PowerAttack()
	{
		StartCoroutine(PowerUp());
	}

	IEnumerator PowerUp()
	{
		float oldDamage = Sword.fSwordDamage;
		Sword.fSwordDamage = Sword.fSwordDamage * fAddForce_Damage;
		GameObject particle = Instantiate(PrimalySkill_Particle, AttackPoint.transform);

		// ��莞�ԗL��
		yield return fRecast_Primaly / 0.5;

		Destroy(particle);
		Sword.fSwordDamage = oldDamage;
	}
	//=====================================================

	// secondalySkill =====================================
	void PhysicalUP()
	{
		
	}

	//IEnumerator StatusUp()
	//{
	//	float oldStatus = ;

	//	GameObject particle = Instantiate(SecondlySkill_Particle, AttackPoint.transform);

	//	yield return fRecast_Secondly / 0.5;

	//	Destroy(particle);
	//	Sword.fSwordDamage = oldStatus;
	//}
	////===================================================

	

	// �����x�Z���T�[ =====================================
	public void BeginEstimatingVelocity()
	{
		FinishEstimatingVelocity();

		routine = StartCoroutine(EstimateVelocityCoroutine());
	}

	public void FinishEstimatingVelocity()
	{
		if (routine != null) // routine�̒��g������Ȃ�
		{
			StopCoroutine(routine); // �R���[�`�����~�߂�
			routine = null; // ������
		}
	}

	// �����x�`�F�b�N
	public Vector3 GetAccelerationEstimate()
	{
		Vector3 average = Vector3.zero;

		for (int i = 2 + sampleCount - velocitySamples.Length; i < sampleCount; i++)
		{
			if (i < 2) continue;

			int first = i - 2;
			int second = i - 1;

			Vector3 v1 = velocitySamples[first % velocitySamples.Length];
			Vector3 v2 = velocitySamples[second % velocitySamples.Length];
			average += v2 - v1;
		}
		average *= (1.0f / Time.deltaTime);

		return average;
	}

	
	private IEnumerator EstimateVelocityCoroutine()
	{
		Vector3 previousPosition = transform.forward;    // ���̑O�������擾
		sampleCount = 0;

		// �i���ɉ�
		while (true) 
		{
			// ���ׂčŌ�܂ő҂�
			yield return new WaitForEndOfFrame();

			// ���x�W��
			float velocityFactor = 1.0f / Time.deltaTime;

			// Length�̒l�͈͂ŏo��
			int v = sampleCount % velocitySamples.Length;        
			sampleCount++;

			// �����L�^
			velocitySamples[v] = velocityFactor * (transform.forward - previousPosition);
			Debug.Log(velocitySamples[v]);

			// �X�V
			previousPosition = transform.forward; 
		}

    }
	// ====================================================
}

