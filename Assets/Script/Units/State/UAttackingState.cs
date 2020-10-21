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
        if (Vector3.Distance(_unit._target.transform.position, _unit.transform.position) >= _unit._stats.Range.Value)
        {
            return UnitStateController.States.Moving;
        }
        return UnitStateController.States.None;
    }

    public override void Update()
    {
        if (_unit.InRange(_unit._target))
        {

        }
    }
}
