using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager 
{
    [SerializeField] BGMListData BGMData;
    [SerializeField] AudioSource BGMSource;

    [SerializeField] SEListData SEData;

    public SoundManager(/*BGMData,*/ SEListData _sedata/*, BGMSource*/)
    {
        SEData = _sedata;
        
    }

    // BGM再生 ******************************************************
    public void PlayBGM(BGMData.Tag _tag)
    {
        BGMData data = BGMData.BGMList.Find(data => data.tagname == _tag);
        BGMSource.clip = data.audioClip;

        BGMSource.Play();
    }
    //***************************************************************

    // SE再生 *******************************************************
    public void PlaySE(SEData.Tag _tag, GameObject _playuser, float _blend)
    {
        Debug.LogWarning("消えないAudioSource発生中");
        SEData data = SEData.SEList.Find(data => data.tagname == _tag);
        AudioSource audioSource;
        audioSource = _playuser.AddComponent<AudioSource>();
        audioSource.clip = data.audioClip;

        _playuser.AddComponent<DeleteSE>();

        audioSource.spatialBlend = _blend;
        audioSource.Play();
    }
    //***************************************************************
}
