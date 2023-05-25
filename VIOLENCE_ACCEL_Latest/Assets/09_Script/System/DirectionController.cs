using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 
public class DirectionController : MonoBehaviour
{
    public SoundManager soundManager;
    public PostController postController;

    [Header("サウンド関連")]
    [SerializeField] protected BGMListData BGMData;
    [SerializeField] protected SEListData SEData;
    AudioSource BGMSource;

    [Header("視界エフェクト関連")]
    [SerializeField] protected PostProcessVolume DamageView;
    [SerializeField] protected PostProcessVolume BlockView;
    [SerializeField] protected PostProcessVolume FlashView;
    [SerializeField] protected PostProcessVolume DarkView; 

    private void Start()
    {
        // 音データを登録
        soundManager = new SoundManager(/*BGMData,*/ SEData/*, BGMSource*/);

        // エフェクション
        //postController = new PostController(DamageView, BlockView/*, FlashView, DarkView*/);
    }
}

