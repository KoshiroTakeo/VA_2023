public class HealthNode : Node
{
    private EnemyAI ai;
    private float threshold;

    public HealthNode(EnemyAI _ai, float _threshold)
    {
        this.ai = _ai;
        this.threshold = _threshold;
    }

    public override NodeState Evaluate()
    {
        //Debug.Log("HealthNode / HPó‹µ•]‰¿’†");
        return ai.currentHealth <= threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
