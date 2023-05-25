using UnityEngine;
using VR.Enemys;

public class SwordCollider : MonoBehaviour
{
    SwordWeapon Sword;
    public float fSwordDamage = 3;



    

   

    public void SetSwordWeapon(SwordWeapon _sword)
    {
        Sword = _sword;
        Sword.OnHaptic(0.2f, 0.3f);
    }

    void Damage(IDamageble<float> damageble)
    {
        damageble.AddDamage(fSwordDamage);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);

        if (collider.gameObject.CompareTag("Enemy"))
        {
            Damage(collider.gameObject.GetComponent<MasterEnemy>());
            Sword.OnHaptic(0.8f, 0.3f);
        }

    }
}
