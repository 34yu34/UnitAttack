using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatExpandable : Stat
{
    private float _curr;
    public override float Value
    {
        get { return _curr; }
    }

    public StatExpandable(float val = 0.0f) : base(val)
    {
        
    }

    public void Remove(float val)
    {
        _curr -= val;

        CheckCurr();
    }

    public override void ResetStat()
    {
        base.ResetStat();
        _curr = _base;
    }

    protected override void CheckMod()
    {
        base.CheckMod();
        CheckCurr();
    }

    protected void CheckCurr()
    {
        if (_curr > _mod)
        {
            _curr = _mod;
        }

        if (_curr < 0.0f)
        {
            _curr = 0.0f;
        }
    }
}
