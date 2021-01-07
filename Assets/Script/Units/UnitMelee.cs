using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMelee : Unit
{

    public override void LaunchAttack()
    {
        if (CanAttack())
        {
            AttackInfo att = AttackInfo.Calculate(_stats.Attack);
            _curr_target.ReceiveDamage(CalcAttackDamage());
            OnAttackHit(_curr_target, att);
        }
    }

}
