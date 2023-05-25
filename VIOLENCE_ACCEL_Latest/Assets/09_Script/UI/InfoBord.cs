//============================================================
// InfoBord.cs
//======================================================================
// 開発履歴
//
// 2023/2/4 MVP方式　View 
//
//======================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR.Players;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class InfoBord : MonoBehaviour, IInfoBord
{

    public PlayerParameter Parameter;

    // 表示するUI達
    [SerializeField] Slider HPSlider;
    [SerializeField] Slider ShirdSlider;

    [SerializeField] TextMeshProUGUI DebugText;

    [SerializeField] InfoBord_Presenter presenter;

    bool Comp = false;

    // Viewテスト
    public PlayerParameter ThrowData
    {
        get => Parameter;
        
        set => Parameter = value;
    }

    private void FixedUpdate()
    {
        if (Parameter == null)
        {
            
            Comp = presenter.Set(); // 正しいんか？
                                    // 準備出来る前に実行しているのでエラーが出る？
        }

        Parameter = ThrowData;
       

        HPSlider.value = Parameter.CurrentHPValue();
        ShirdSlider.value = Parameter.CurrentShild();

    }
}
