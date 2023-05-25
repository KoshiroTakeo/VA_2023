//
// 未使用　⇒　テクスチャで行う
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 

public class PostController 
{
    Coroutine Cor_Damage;
    Coroutine Cor_Block;

    PostProcessVolume DamageView;
    PostProcessVolume BlockView;
    PostProcessVolume FlashView;
    PostProcessVolume DarkView;
    WaitForSeconds step; 

    bool bPlayDamage;
    bool bPlayBlock;
    bool bPlayFlash;
    bool bPlayDark; 
    
    public PostController(PostProcessVolume _DamageView, PostProcessVolume _BlockView /*PostProcessVolume _FlashView, PostProcessVolume _DarkView*/)
    {
        DamageView = _DamageView;
        BlockView = _BlockView;
        //FlashView = _FlashView;
        //DarkView = _DarkView; 
        
        step = new WaitForSeconds(0.1f);
        bPlayDamage = false;
        bPlayBlock = false;
        bPlayFlash = false;
        bPlayDark = false;
    }

    public void Damage(float _volume) // _volumeは脅威的なダメージほど大きくなる（Max1.0f）
    {
        //// 途中ならコルーチンを止める
        //Debug.Log(bPlayDamage);
        //if (bPlayDamage == true) StopCoroutine(Cor_Damage);
        //Cor_Damage = StartCoroutine(StartEffection(_volume, DamageView, bPlayDamage));
    }

    public void Block(float _volume) // _volumeは脅威的なダメージほど大きくなる（Max1.0f）
    {
        //// 途中ならコルーチンを止める
        //if (bPlayBlock == true) StopCoroutine(Cor_Block);
        //Cor_Block = StartCoroutine(StartEffection(_volume, BlockView, bPlayBlock));
    }

    IEnumerator StartEffection(float _volume, PostProcessVolume _postProcessVolume, bool _bPlay)
    {
        
        _bPlay = true;
        float weight = _volume; 
        
        while (weight >= 0.1f)
        {
            _postProcessVolume.weight = weight;
            yield return step;
            weight -= 0.08f;
        }
        _postProcessVolume.weight = 0; _bPlay = false;
    }
}

// コラム
// https://gametukurikata.com/ui/damagepointui


