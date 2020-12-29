using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[Serializable]
public class UnitStateController
{
    public enum States
    {
        None,
        Moving,
        Attacking
    }

    protected UnitState _state;
    protected Unit _unit;

    public UnitStateController(Unit u)
    {
        _state = new UMovingState(u);
        _unit = u;
    }

    public void Update()
    {
        _state.Update();

        SetNextState();
    }

    private void SetNextState()
    {
        States s = _state.NextState();
        switch (s)
        {
            case States.None:
                break;
            case States.Moving:
                _state = new UMovingState(_unit);
                break;
            case States.Attacking:
                _state = new UAttackingState(_unit);
                break;
        }
    }
}
