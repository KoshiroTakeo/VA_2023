using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : WeaponBase,IWeaponAction
{
    //[SerializeField] GameObject MazzleFire; // エフェク
    Transform mazzle;

    float fDeleteTime = 10f;

    private void Start()
    {
        mazzle = this.gameObject.transform.Find("Muzzle");
        
    }

    public string PrimalySkill()
    {
        
        string debugtext = "now charge Gun" + fRecast_Primaly;
        
        if (bStanby_Primaly == true) return debugtext;
        StartCoroutine(Recasttime_Primaly(fRecast_Primaly));
        
        FireBullet();

        return debugtext;
    }

    public void SecondalySkill()
    {  
        if (bStanby_Secondly == true) return;
        StartCoroutine(Recasttime_Secondly(fRecast_Secondly));

        SpecialBullet();
    }

    void FireBullet()
    {
        GameObject spawnedBullet = Instantiate(PrimaryBullet, mazzle.position, mazzle.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = fBulletSpeed * mazzle.forward;
        spawnedBullet.GetComponent<Bullet>().fBulletDamage = fAttack;
        spawnedBullet.GetComponent<Bullet>().tag = Bullet.OWNER.PLAYER;

        Instantiate(PrimalySkill_Particle, mazzle);

        Direction.soundManager.PlaySE(SEData.Tag.BulletFire_Primary, spawnedBullet, 1f);
        //Debug.Log(fBulletSpeed);
        Destroy(spawnedBullet, fDeleteTime);
    }

    void SpecialBullet()
    {
        GameObject spawnedBullet = Instantiate(SecondlyBullet, mazzle.position, mazzle.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = fBulletSpeed * mazzle.forward;
        spawnedBullet.GetComponent<Bullet>().fBulletDamage = fAttack;
        spawnedBullet.GetComponent<Bullet>().tag = Bullet.OWNER.PLAYER;
        Destroy(spawnedBullet, fDeleteTime);
    }


}
