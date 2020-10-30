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
        _unit._rb.velocity = Vector3.zero;
    }

    public abstract UnitStateController.States NextState();
    public abstract void Update();
    public abstract string Name();
}
