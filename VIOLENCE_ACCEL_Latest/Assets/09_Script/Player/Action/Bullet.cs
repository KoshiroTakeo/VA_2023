//======================================================================
// Bullet.cs
//======================================================================
// 開発履歴
//
// 2022/11/04 author：ダメージを食らうように
// 
//
//======================================================================
using UnityEngine;
using VR.Enemys;
using VR.Players;

public class Bullet : MonoBehaviour
{
    // 要素増えたらインターフェース
    public float fBulletDamage { get; set; }

    public enum OWNER
    {
        ENVIRONMENT = 0,
        PLAYER = 1,
        ENEMY = 2,
        
        MAX
    };
    public OWNER tag;

    

    void Damage(IDamageble<float> damageble)
    {
        damageble.AddDamage(fBulletDamage);
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch(tag)
        {
            case OWNER.ENVIRONMENT:
                if (collider.gameObject.CompareTag("Enemy"))
                {
                    Damage(collider.gameObject.GetComponent<MasterEnemy>());
                    Destroy(this.gameObject);
                }
                if (collider.gameObject.CompareTag("Player"))
                {
                    Damage(collider.gameObject.GetComponent<MasterPlayer>());
                    Destroy(this.gameObject);
                }
                break;

            case OWNER.PLAYER:
                if (collider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("hit");
                    Damage(collider.gameObject.GetComponent<MasterEnemy>());
                    Destroy(this.gameObject);
                }
                break;

            case OWNER.ENEMY:
                if (collider.gameObject.CompareTag("Player"))
                {
                    Damage(collider.gameObject.GetComponent<MasterPlayer>());
                    Destroy(this.gameObject);
                }
                break;
            default:
                break;
        }

        
        
    }

  

}
