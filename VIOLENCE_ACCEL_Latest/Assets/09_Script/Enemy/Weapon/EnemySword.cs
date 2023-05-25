using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : EnemyWeapon, IWeaponAction
{
	
	[SerializeField] GameObject AttackPoint = null; // あたり判定オブジェクト



	private void Start()
	{
		
	}

	private void Update()
	{
		
	}

	void SlashAttack()
	{
		StartCoroutine("SlashColliderOn");
	}

	IEnumerator SlashColliderOn()
    {
		AttackPoint.SetActive(true);

		yield return WTS_SetTime_Primaly;

		AttackPoint.SetActive(false);
	}
	


	// スキル発動とリキャスト
	public string PrimalySkill()
	{
		string debugtext = "now charge";

		if (bStanby_Primaly == true) return debugtext;
		debugtext = "Shot";
		StartCoroutine(Recasttime_Primaly(fRecast_Primaly));

		PowerAttack();

		return debugtext;
	}

	public void SecondalySkill()
	{
		if (bStanby_Secondly == true) return;
		StartCoroutine(Recasttime_Secondly(fRecast_Secondly));

		PhysicalUP();
	}
	void PowerAttack()
	{
		Debug.Log("斬撃強化");
	}

	void PhysicalUP()
	{
		Debug.Log("身体強化");
	}
}
