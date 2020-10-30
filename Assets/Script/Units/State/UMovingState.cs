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

    public override UnitStateController.States NextState()
    {
        if (_unit._curr_target != null && _unit.InRange(_unit._curr_target))
        {
            return UnitStateController.States.Attacking;
        }
        return UnitStateController.States.None;
    }

    public override void Update()
    {
        _unit._rb.velocity = _unit._stats.MovementSpeed.Value * _unit._side_controller._path.Direction(0);
    }
}
