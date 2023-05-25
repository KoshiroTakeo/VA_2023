//*********************************************************
// Behiviour Treeを使った敵AI
//*********************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float startingHealth;    // 初期HP
    [SerializeField] private float lowHealthThreshold;// 退避を開始するHP
    [SerializeField] private float healthRestoreRate; // 

    [SerializeField] private float chasingRange;      // 追跡範囲
    [SerializeField] private float shootingRange;     // 攻撃範囲

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Cover[] avaliableCovers;

    private Material material;
    private Transform bestCoverSpot;
    private NavMeshAgent agent;

    private Node topNode;

    private float _currentHealth;

    [SerializeField]
    public float currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, startingHealth); }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponent<MeshRenderer>().material;
    }

    private void Start()
    {
        // 初期HPに更新
        _currentHealth = startingHealth;
        
        // Treeの形成
        ConstructBehaviourTree();
    }

    // ツリー形成
    private void ConstructBehaviourTree()
    {
        // 各行動のNodeをリーフから生成
        IsCoverAvaliableNode coverAvaliableNode = new IsCoverAvaliableNode(avaliableCovers, playerTransform, this); // 逃げ場所へ到着
        GoToCoverNode goToCoverNode = new GoToCoverNode(agent, this); // 逃げる
        HealthNode healthNode = new HealthNode(this, lowHealthThreshold); // HP確認
        IsCovereNode isCovereNode = new IsCovereNode(playerTransform, transform); // 判定
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this); // 追跡行動
        RangeNode chasingRangeNode = new RangeNode(chasingRange, playerTransform, transform); // 追跡範囲確認行動
        RangeNode shootingRangeNode = new RangeNode(shootingRange, playerTransform, transform); // 攻撃範囲確認行動
        ShootNode shootNode = new ShootNode(agent, this); // 攻撃行動

        // 
        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode }); // 追跡中判定/追跡中
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, shootNode }); // 攻撃中判定/攻撃中


        Sequence goToCoverSequence = new Sequence(new List<Node> { coverAvaliableNode, goToCoverNode}); // 逃げ場所がないなら、次のNodeへ
        Selector findCoverSelector = new Selector(new List<Node> { goToCoverSequence, chaseSequence}); // Sequence結果が失敗なら、次のSequenceへ
        Selector tryToTakeCoverSelector = new Selector(new List<Node> { isCovereNode, findCoverSelector }); // プレイヤーを見たら、次のSelectorへ
        Sequence mainCoverSequence = new Sequence(new List<Node> { healthNode, tryToTakeCoverSelector }); // HPが低いなら、次のSelectorへ

        topNode = new Selector(new List<Node> { mainCoverSequence, shootSequence, chaseSequence }); // 逃げる/攻撃/追跡 左から順に優先され、処理される。各Sequencerで失敗を返したら次のNodeを読む

    }



    private void Update()
    {
        // 状況判断し、行動実行
        topNode.Evaluate();


        if(topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.white);
        }

        

        currentHealth += Time.deltaTime * healthRestoreRate;
    }

    public void Damage()
    {
        Debug.Log("Damage");
        currentHealth -= 10f;
    }

    public void SetColor(Color _color)
    {
        
        material.color = _color;
    }

    // 最も近い逃げ場所を記憶
    public void SetBestCover(Transform bestSpot)
    {
        this.bestCoverSpot = bestSpot;
    }

    // 最も近い逃げ場所を出力
    public Transform GetBestCoverSpot()
    {
        return bestCoverSpot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Damage();
        }
    }
}
