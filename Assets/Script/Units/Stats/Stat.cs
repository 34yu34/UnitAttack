using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stat
{
    public float _base;
    protected float _mod;

    public virtual float Value
    {
        get { return _mod; }
    }
    protected List<StatModification> _timed_buffs;

    public Stat(float base_val = 0.0f)
    {
        _base = base_val;
        ResetStat();
    }

    public virtual void ResetStat()
    {
        _mod = _base;
        _timed_buffs = new List<StatModification>();
    }

    public void AddBonus(StatModification.ModifierType t, float val, float time)
    {
        StatModification modif = new StatModification(t, val, time);
        modif.bind(_base);
        _mod += modif.DeltaVal;

        CheckMod();


        _timed_buffs.Add(modif);
    }

    public void Update()
    {
        foreach (StatModification m in _timed_buffs)
        {
            m.Update();
        }

        TimeCheckkModif();
    }

    public override bool Equals(object a)
    {
        
        return a.Equals(this.Value);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public static bool operator ==(Stat s, float a)
    {
        return s.Value == a;
    }
    public static bool operator !=(Stat s, float a)
    {
        return s.Value != a;
    }

    public static bool operator >(Stat s, float a)
    {
        return s.Value > a;
    }
    public static bool operator <(Stat s, float a)
    {
        return s.Value < a;
    }

    public static bool operator >=(Stat s, float a)
    {
        return s.Value >= a;
    }
    public static bool operator <=(Stat s, float a)
    {
        return s.Value <= a;
    }

    protected virtual void CheckMod()
    {
        if (_mod < 0.0f)
        {
            _mod = 0.0f; // cant go negative
        }
    }

    public bool IsEmpty()
    {
        return _mod <= 0.0f;
    }

    protected void TimeCheckkModif()
    {
        for (int i = 0; i < _timed_buffs.Count; i += 1)
        {
            while (_timed_buffs.Count > i && _timed_buffs[i].CheckTime())
            {
                RemoveModif(i);
            }
        }
    }
    
    protected void RemoveModif(int index)
    {
        _mod -= _timed_buffs[index].DeltaVal;
        _timed_buffs.RemoveRange(index, 1);
    }
}
