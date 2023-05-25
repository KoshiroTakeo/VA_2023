using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR.Enemys;

public class Defence : EliteState
{
    public Defence(int _value) : base(_value)
    {
        value = _value;
        name = STATE.OFFENCE;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Updata()
    {
        if (EvaluationState() == STATE.DEFENCE) NextState(new Offence(value));
    }

    public override void Exit()
    {
        base.Exit();
    }
}
