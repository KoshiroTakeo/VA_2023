//============================================================
// シーン上のプレイヤー
//======================================================================
// 開発履歴
// 20220728:可用性向上のため再構築
// https://light11.hatenadiary.com/entry/2019/12/26/225232
//======================================================================
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace VR.Players
{
    public class MasterPlayer : MonoBehaviour, IInputable, IDamageble<float>
    {
        public bool Succes = false;

        // 必要コンポーネント
        CharacterController PlayerCharacter { get; set; }
        Rigidbody PlayerRB;
        ActionManager ACManager;
       [SerializeField] DirectionController Direction;
        RaytoTarget rayinfo;         
        
        // 移動に必要なアンカー
        GameObject AnchorObject;
        GameObject CenterEyeAnchor;
        Vector3 InitirizeAnchorPos = new Vector3();         
        
        // Weapon発生場所
        protected Transform LeftHand;
        protected Transform RightHand;
        // VR用コンポーネント
        protected XRBaseController XRController_L;
        protected XRBaseController XRController_R;

        // Playerのパラメータデータ
        private AsyncOperationHandle PlayerData_handle;
        [SerializeField] PlayerData Data;
        [SerializeField] PlayerParameter Parameter;         
        
        // 移動クラス
        HoverMover HoverMove;         
        
        // デバック
        public TextMeshProUGUI DebugText;
        GameObject UIField;
        public Slider slider;
        public Slider hpslider; 
        
        private void Awake()
        {
            Succes = false;

            Addressables.LoadAssetAsync<PlayerData>("PlayerData_handle").Completed += op =>
            {
                Data = op.Result;
                Addressables.Release(op);
            };

            PlayerCharacter = GetComponent<CharacterController>();
            PlayerRB = GetComponent<Rigidbody>();
            
            // この辺キモイ
            LeftHand = GameObject.Find("Player_XRRig/Camera Offset/LeftHand Controller").transform;
            XRController_L = GameObject.Find("Player_XRRig/Camera Offset/LeftHand Controller").GetComponent<XRBaseController>();
            RightHand = GameObject.Find("Player_XRRig/Camera Offset/RightHand Controller").transform;
            XRController_R = GameObject.Find("Player_XRRig/Camera Offset/RightHand Controller").GetComponent<XRBaseController>();
            CenterEyeAnchor = GameObject.Find("Player_XRRig/Camera Offset/Main Camera"); // キモイ
            UIField = GameObject.Find("Player_XRRig/PlayerUI");

            
        }


        private void Start()
        {
            //Data = GameObject.FindWithTag("Manager").GetComponent<GameManager>().SetPlayerData; // ロードしたデータを受け取る

            //Succes = false;

            //// 能力決定
            //Parameter = new PlayerParameter(Data);

            //// 音、エフェクト系演出
            //Direction = GameObject.FindWithTag("Manager").GetComponent<DirectionController>();
            //rayinfo = new RaytoTarget();

            //// コントローラーの操作系
            //ACManager = new ActionManager(Data, LeftHand, XRController_L, RightHand, XRController_R, Direction);

            //// アンカーを生成（）
            //AnchorObject = new GameObject("AnchorObject");
            //MoveAnchor moveAnchor = AnchorObject.AddComponent<MoveAnchor>();
            //moveAnchor.SetAnchor(CenterEyeAnchor, this.gameObject);

            //// 移動系
            //HoverMove = new HoverMover();

            //Succes = true;
        }

        private void Update()
        {
            if(Data && Succes == false)
            {
                // 能力決定
                Parameter = new PlayerParameter(Data);
                

                // 音、エフェクト系演出
                Direction = GameObject.FindWithTag("Manager").GetComponent<DirectionController>();
                rayinfo = new RaytoTarget();

                // コントローラーの操作系
                ACManager = new ActionManager(Data, LeftHand, XRController_L, RightHand, XRController_R, Direction);

                // アンカーを生成（）
                AnchorObject = new GameObject("AnchorObject");
                MoveAnchor moveAnchor = AnchorObject.AddComponent<MoveAnchor>();
                moveAnchor.SetAnchor(CenterEyeAnchor, this.gameObject);

                // 移動系
                HoverMove = new HoverMover();

                Succes = true;

                
            }
        }

        // フレームレートを維持した動きにしたいもの
        void FixedUpdate()
        {
            if(Succes == false)
            {
                Debug.LogWarning("PlayerData読込中");
                return;
            }

            //rayinfo.WatchtoObject(CenterEyeAnchor); 

            // 体幹移動
            HoverMove.HeadInclinationMove(PlayerCharacter, AnchorObject.transform.position, InitirizeAnchorPos, Parameter.fSpeed);

            // スラスタ
            HoverMove.ThrusterControll(PlayerRB, this.transform, Parameter.fSpeed);
            
            // シールドジェネレーター
            Parameter.RecoverShild(PlayerRB.velocity.magnitude);

           
        }

        // ダメージ処理
        public void AddDamage(float _damage)
        {
            float damage = 0; 

            if (Parameter.nShild <= _damage)
            {
                damage = _damage - Parameter.nShild;
                Parameter.nShild = 0;
                Parameter.nHP = Parameter.nHP - (int)damage;
                //Direction.postController.Damage(_damage / (Parameter.nHP / 10)); 
                Direction.soundManager.PlaySE(SEData.Tag.DamageHit, this.gameObject, 1.0f); 
            }
            else
            {
                Parameter.nShild = Parameter.nShild - (int)_damage; 
                //Direction.postController.Block(_damage / (Parameter.nShild / 10)); 
                Direction.soundManager.PlaySE(SEData.Tag.DamageHit, this.gameObject, 1.0f); ;
            }
        }

        // パラメーター受け渡し
        public PlayerParameter ThrowData()
        {
            
            return Parameter;
        }

        // 左コントローラー処理 ===================================================================
        public void PressTriggerAction_L(bool trigger)
        {
            if (trigger == false) return;
            DebugText.text = ACManager.PrimalySkill_L();
        }
        public void HoldTriggerAction_L(float value)
        {
        }
        public void PressGripAction_L(bool trigger)
        {
            HoverMove.Thruster_L(trigger);
            if (trigger == false) return;
        }
        public void HoldGripAction_L(float value)
        {
        }
        public void PressButton_X(bool trigger)
        {
            if (trigger == false) return; ACManager.SecondalySkill_L();
        }
        public void PressButton_Y(bool trigger)
        {
            if (trigger == false) return; ACManager.ChangeWeapon_L();
        }
        public void PressButton_Menu(bool trigger)
        {
            if (trigger == false) return;
        }
        //=========================================================================================          
        
        // 右コントローラー処理 ===================================================================
        public void PressTriggerAction_R(bool trigger)
        {
            if (trigger == false) return; ACManager.PrimalySkill_R();
        }
        public void HoldTriggerAction_R(float value)
        {
        }
        public void PressGripAction_R(bool trigger)
        {
            HoverMove.Thruster_R(trigger);
            if (trigger == false) return;
        }
        public void HoldGripAction_R(float value)
        {
        }
        public void PressButton_A(bool trigger)
        {
            if (trigger == false) return; ACManager.SecondalySkill_R();
        }
        public void PressButton_B(bool trigger)
        {
            if (trigger == false) return; ACManager.ChangeWeapon_R();
        }
        public void PressButton_Start(bool trigger)
        {
            if (trigger == false) return;
        }
        //===============================================================================         
    }
}

