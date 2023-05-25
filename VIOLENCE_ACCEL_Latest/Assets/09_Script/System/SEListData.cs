using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Create SEListData")]

public class SEListData : ScriptableObject
{ 
    [Header("BGMƒŠƒXƒg")]
    public List<SEData> SEList;

}

// SE *******************************************
[System.Serializable]
public class SEData
{
    public enum Tag
    {
        BulletFire_Primary,
        BulletFire_Secondly,
        BulletRecast_Primary,
        BulletRecast_Secondly,

        Skill_Primary,
        Skill_Secondly,

        Sword_Swing,
        SwordHit_Physical,
        SwordHit_Lazer,

        SheldHit,
        ShildBlock_Physical,
        ShildBlock_Lazer,
        ShildBreak_Physical,
        ShildBreak_Lazer,

        DamageHit,
        FatalHit,

        HitAttack,

        Fly,
        Flying,
        Break,
        Breaking,

        NULL
    }

    public Tag tagname;
    public AudioClip audioClip;
}
//***********************************************
