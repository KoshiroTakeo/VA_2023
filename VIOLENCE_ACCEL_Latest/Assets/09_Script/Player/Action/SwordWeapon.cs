using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordWeapon : WeaponBase, IWeaponAction
{
	SwordCollider Sword;
	GameObject AttackPoint = null; // あたり判定オブジェクト
	float fAddForce_Damage = 2.0f; // 剣の基本威力


	// 加速度を計算に必要な部分 =====================
	private Coroutine routine;
	private Vector3[] velocitySamples; // 記録する値たち

	private int sampleCount;
	private float fOnAttackVelocity = 1100; // どれだけの強さで振ったら反応するか
	//===========================================



	private void Start()
	{
		velocitySamples = new Vector3[5];
		BeginEstimatingVelocity(); // コルーチンを回し始める

		AttackPoint = transform.Find("AttackPoint").gameObject;
		Sword = AttackPoint.GetComponent<SwordCollider>();
		Sword.SetSwordWeapon(this); // 自身を登録
	}

    private void FixedUpdate()
	{
		if (this.gameObject.activeSelf == true)
		{
			// 加速度計算を行う
			SlashAttack();
		}
		else if (this.gameObject.activeSelf == false)
		{
			// 剣のあたり判定を消す
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

		// 能力発動
		PowerAttack();

		return debugtext;
	}

	public void SecondalySkill()
	{
		if (bStanby_Secondly == true) return;
		StartCoroutine(Recasttime_Secondly(fRecast_Secondly));

		// 能力発動
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

		// 一定時間有効
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

	

	// 加速度センサー =====================================
	public void BeginEstimatingVelocity()
	{
		FinishEstimatingVelocity();

		routine = StartCoroutine(EstimateVelocityCoroutine());
	}

	public void FinishEstimatingVelocity()
	{
		if (routine != null) // routineの中身があるなら
		{
			StopCoroutine(routine); // コルーチンを止める
			routine = null; // 初期化
		}
	}

	// 加速度チェック
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
		Vector3 previousPosition = transform.forward;    // 剣の前方向を取得
		sampleCount = 0;

		// 永遠に回す
		while (true) 
		{
			// すべて最後まで待つ
			yield return new WaitForEndOfFrame();

			// 速度係数
			float velocityFactor = 1.0f / Time.deltaTime;

			// Lengthの値範囲で出力
			int v = sampleCount % velocitySamples.Length;        
			sampleCount++;

			// 差を記録
			velocitySamples[v] = velocityFactor * (transform.forward - previousPosition);
			Debug.Log(velocitySamples[v]);

			// 更新
			previousPosition = transform.forward; 
		}

    }
	// ====================================================
}

