using UnityEngine;
using UnityEngine.UI;
using VR.Enemys;

public class LifeBar : MonoBehaviour
{
    [Header("Prefab内のHPBar")]
    public GameObject bar;
    public static LifeBar instance;

    private GameObject PlayerObj;
    private GameObject EnemyObj;

    public Slider MainSlider;  // 削れる部分
    public Slider LateSlider; // 遅れて削れる部分

    private int fMaxHP;
    private int fHp;

   
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        
        PlayerObj = GameObject.FindWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        // Player方向へ常に向く
        this.transform.LookAt(PlayerObj.transform);

    }


    // 現在のHPを入れる
    public void SetLifeBar(GameObject _enemy, int _HP)
    {
        this.gameObject.transform.position = _enemy.transform.position;
        EnemyObj = _enemy;

        fHp = fMaxHP = _HP;
        MainSlider.value = 1;
        LateSlider.value = 1;

        // 親へ移動
        transform.SetParent(EnemyObj.transform);
    }

    // HPに変化があった時
    public void UpdataLife(int _currentHP)
    {
        float _percent;
        fHp = _currentHP;
        _percent = (float)_currentHP / (float)fMaxHP;
        MainSlider.value = _percent;
        Debug.Log(_currentHP + "///" + _percent);
    }

    public void DirectionView(bool _onmovie)
    {
        if (_onmovie == false) return;


    }


}