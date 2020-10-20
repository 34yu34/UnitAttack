using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMovingState : UnitState
{
    private Vector3 _direction;
    
    public UMovingState(Unit u) : base(u)
    {

    }

    public override string Name()
    {
        return "Moving";
    }

    public override void Update()
    {
        
    }

    public override UnitStateController.States NextState()
    {
        if (Vector3.Distance(_unit._target.transform.position, _unit.transform.position) <= _unit._stats.Range.Value)
        {
            return UnitStateController.States.Attacking;
        }
        return UnitStateController.States.None;
    }
}
