using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace VR.Enemys
{
    public class EliteEnemy : MasterEnemy
    {
        // 攻守のバランス値
        public int evaluteValue { get; set; }

        private Node topNode;

        // 目的地
        public Vector3 path;
        public GameObject racerobj;
        
        

        private void Start()
        {
            SetUP();
            path = PlayerPos.transform.position;
            Tree();

            
        }

        private void Tree()
        {
            OfenceAction ofenceAction = new OfenceAction(this.gameObject, racerobj.transform, Parameter.fSpeed);
            DefendAction defendAction = new DefendAction();

            IsDangerous isDangerous = new IsDangerous(Parameter, 0.5f); // HPが下回っているか
            IshavePath ishavePath = new IshavePath(this, PlayerPos, racerobj.transform, Parameter.fSpeed); // 目的地を探索し、レーサーを向かわせる

            
            Sequence goaltoPath = new Sequence(new List<Node> {ishavePath, ofenceAction });
            Sequence checkTactics = new Sequence(new List<Node> {isDangerous, defendAction});

            topNode = new Selector(new List<Node> {checkTactics,goaltoPath});
        }

        private void FixedUpdate()
        {
            // 状況判断し、行動実行
            topNode.Evaluate();

            //CurrentState = CurrentState.Process();
        }
        
       
    }

}
