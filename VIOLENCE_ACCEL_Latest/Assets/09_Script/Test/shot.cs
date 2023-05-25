using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public Transform mazzle;

    public GameObject PrimaryBullet;

    private void Start()
    {
        mazzle = this.gameObject.transform.Find("Muzzle");

    }

    public void FireBullet()
    {
        Debug.Log(this.transform.position);
        if (mazzle == null) return;
        GameObject spawnedBullet = Instantiate(PrimaryBullet, mazzle.position, mazzle.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = 40 * mazzle.forward;
        spawnedBullet.GetComponent<Bullet>().fBulletDamage = 1;
        Destroy(spawnedBullet, 2);
    }
}
