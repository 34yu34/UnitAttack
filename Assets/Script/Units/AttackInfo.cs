using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo
{
    private float _damage;
    public float Damage => _damage;
    
    private bool _is_crit;
    public bool IsCrit => _is_crit;

    public AttackInfo()
    {
        _damage = 0;
        _is_crit = false;
    }

    public static AttackInfo Calculate(float damage, float crit_chance = 0.0f, float crit_multiplier = 2.0f)
    {
        AttackInfo att = new AttackInfo();
        float chances = Random.value;
        if (chances < crit_chance)
        {
            att._damage = damage * crit_multiplier;
            att._is_crit = true;
        }
        else
        {
            att._damage = damage;
            att._is_crit = false;
        }

        return att;
    }
}
