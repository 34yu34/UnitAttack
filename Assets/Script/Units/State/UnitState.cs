using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class UnitState
{ 
    public Unit _unit;
    // Start is called before the first frame update
    public UnitState(Unit u)
    {
        _unit = u;
    }

    public abstract UnitStateController.States NextState();
    public abstract void Update();
    public abstract string Name();
}
