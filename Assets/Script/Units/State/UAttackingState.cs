using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAttackingState : UnitState
{

    public UAttackingState(Unit u) : base(u)
    {
    }

    public override string Name()
    {
        return "Attacking";
    }

    public override UnitStateController.States NextState()
    {
        if (_unit._targets.Count == 0)
        {
            return UnitStateController.States.Moving;
        }
        return UnitStateController.States.None;
    }

    public override void Update()
    {
        _unit.LaunchAttack();
    }
}
