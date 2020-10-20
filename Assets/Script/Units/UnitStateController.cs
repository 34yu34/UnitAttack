using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public UnitStateController(Unit u)
    {
        _state = new UMovingState(u);
    }
}
