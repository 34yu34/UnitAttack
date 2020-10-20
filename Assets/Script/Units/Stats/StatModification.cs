using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StatModification
{
    public enum ModifierType
    {
        PER,
        FIX
    }

    private ModifierType _type;
    private float _duration;
    private float _timer;
    private float _val;
    private float _delta_val;
    private bool _running;

    public float DeltaVal
    {
        get
        {
            return _delta_val;
        }
    }

    public StatModification(ModifierType type, float val, float duration)
    {
        _type = type;
        _val = val;
        _duration = duration;
        _timer = 0.0f;
        _running = false;
        _delta_val = 0.0f;
    }

    public float bind(float base_val)
    {
        _delta_val = (_type == ModifierType.PER) ? base_val * (1 - _val) : _val;
        _running = true;

        return _delta_val;
    }

    // Update is called once per frame
    public void Update()
    {
        if (_running)
        {
            _timer += Time.deltaTime;
        }
    }

    public bool CheckTime()
    {
        return (_timer >= _duration);
    }
}
