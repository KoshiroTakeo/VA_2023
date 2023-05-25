using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Create BGMListData")]

public class BGMListData : ScriptableObject
{
    [Header("BGMƒŠƒXƒg")]
    public List<BGMData> BGMList;

}

// BGM ******************************************
[System.Serializable]
public class BGMData
{
    public enum Tag
    {
        TITLE,
        BATTLE1,
        BATTLE2,
        STARTGINGLE,
        FANFALE,

        NULL
    }

    public Tag tagname;
    public AudioClip audioClip;
}
//***********************************************


